using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Mobile.Services;

namespace CondoSphere.Mobile.ViewModels
{
    [QueryProperty(nameof(Quota), "Quota")]
    public partial class QuotaDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private UnitQuotaDto quota;

        [ObservableProperty]
        private QuotaBreakdownDto breakdown;

        [ObservableProperty]
        private bool isBusy;

        private readonly ApiClient _apiClient;

        public QuotaDetailsViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        partial void OnQuotaChanged(UnitQuotaDto value)
        {
            if (value != null)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] QuotaDetailsViewModel: Quota set - {value.Description}");
                _ = LoadBreakdownAsync();
            }
        }

        private async Task LoadBreakdownAsync()
        {
            if (Quota == null || IsBusy) return;

            IsBusy = true;
            try
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Loading breakdown for quota {Quota.Id}");
                var result = await _apiClient.GetQuotaBreakdownAsync(Quota.Id);
                if (result != null)
                {
                    Breakdown = result;
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Breakdown loaded successfully");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] LoadBreakdownAsync Error: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", $"Failed to load quota details: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task PayNowAsync()
        {
            if (Quota == null) return;

            // Construct the payment URL for the web app
            // This should match your web app's URL structure
            var paymentUrl = $"{ApiClient.WebBaseUrl}/portal/quotas/{Quota.Id}/pay";

            System.Diagnostics.Debug.WriteLine($"[DEBUG] Opening payment URL: {paymentUrl}");

            try
            {
                // Open the payment page in the device's default browser
                await Launcher.OpenAsync(paymentUrl);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] PayNowAsync Error: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", $"Could not open payment page: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        private async Task UploadProofAsync()
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Select payment proof (bank transfer screenshot, receipt, etc.)"
                });

                if (result != null)
                {
                    IsBusy = true;
                    System.Diagnostics.Debug.WriteLine($"[DEBUG] Uploading proof for quota {Quota.Id}");

                    var success = await _apiClient.SubmitPaymentProofAsync(Quota.Id, result);

                    if (success)
                    {
                        await Shell.Current.DisplayAlert("Success",
                            "Payment proof uploaded successfully. The manager will review and confirm your payment.",
                            "OK");

                        // Update the quota status locally to reflect the change
                        Quota.Status = Core.Enums.UnitQuotaStatus.PendingConfirmation;
                        OnPropertyChanged(nameof(Quota));

                        // Navigate back to the portal
                        await Shell.Current.GoToAsync("..");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "Failed to upload payment proof. Please try again.", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] UploadProofAsync Error: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", $"Could not upload proof: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}