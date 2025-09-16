using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Mobile.Services;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class ChangePasswordViewModel : ObservableObject
    {
        private readonly ApiClient _apiClient;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string currentPassword;

        [ObservableProperty]
        private string newPassword;

        [ObservableProperty]
        private string confirmPassword;

        public ChangePasswordViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [RelayCommand]
        private async Task ChangePasswordAsync()
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(CurrentPassword) || string.IsNullOrWhiteSpace(NewPassword))
            {
                await Shell.Current.DisplayAlert("Validation Error", "Please fill in all fields.", "OK");
                return;
            }

            if (NewPassword != ConfirmPassword)
            {
                await Shell.Current.DisplayAlert("Validation Error", "New passwords do not match.", "OK");
                return;
            }

            if (IsBusy) return;

            IsBusy = true;
            try
            {
                var dto = new ChangePasswordDto
                {
                    CurrentPassword = this.CurrentPassword,
                    NewPassword = this.NewPassword,
                    ConfirmPassword = this.ConfirmPassword
                };

                var (success, message) = await _apiClient.ChangePasswordAsync(dto);

                if (success)
                {
                    await Shell.Current.DisplayAlert("Success", "Your password has been changed successfully.", "OK");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", message, "OK");
                }
            }
            catch (System.Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"An unexpected error occurred: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}