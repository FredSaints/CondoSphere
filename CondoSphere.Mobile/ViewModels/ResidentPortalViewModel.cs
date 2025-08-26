using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Financials;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Mobile.Services;
using CondoSphere.Mobile.Views;
using System.Collections.ObjectModel;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class ResidentPortalViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isBusy;

        public ObservableCollection<UnitQuotaDto> Quotas { get; } = new();
        public ObservableCollection<OccurrenceDto> Occurrences { get; } = new();

        private readonly ApiClient _apiClient;

        public ResidentPortalViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [RelayCommand]
        private async Task LoadDataAsync()
        {
            // This guard clause prevents the user from triggering a refresh while one is already in progress.
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                // Clear existing data before loading new data
                Quotas.Clear();
                Occurrences.Clear();

                // Fetch new data in parallel for efficiency
                var quotasTask = _apiClient.GetMyQuotasAsync();
                var occurrencesTask = _apiClient.GetMyOccurrencesAsync();
                await Task.WhenAll(quotasTask, occurrencesTask);

                var quotasResult = await quotasTask;
                if (quotasResult != null)
                {
                    foreach (var quota in quotasResult)
                    {
                        Quotas.Add(quota);
                    }
                }

                var occurrencesResult = await occurrencesTask;
                if (occurrencesResult != null)
                {
                    foreach (var occurrence in occurrencesResult)
                    {
                        Occurrences.Add(occurrence);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load portal data: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task ViewQuotaDetailsAsync(UnitQuotaDto quota)
        {
            if (quota == null)
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] ViewQuotaDetailsAsync called with null quota");
                return;
            }

            System.Diagnostics.Debug.WriteLine($"[DEBUG] ViewQuotaDetailsAsync → Quota: {quota.Description} (Id={quota.Id})");

            try
            {
                await Shell.Current.GoToAsync("quotas/details", new Dictionary<string, object>
                {
                    ["Quota"] = quota
                });
                System.Diagnostics.Debug.WriteLine("[DEBUG] Navigation to quota details completed");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Navigation to quota details FAILED: {ex}");
                await Shell.Current.DisplayAlert("Navigation Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        private async Task AddOccurrenceAsync()
        {
            // Use relative navigation for global routes
            await Shell.Current.GoToAsync("condos/occurrences/create");
        }
    }
}