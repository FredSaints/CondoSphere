using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Reports;
using CondoSphere.Mobile.Services;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class AdminDashboardViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private AdminDashboardDto stats;

        private readonly ApiClient _apiClient;

        public AdminDashboardViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
            Stats = new AdminDashboardDto();
        }

        [RelayCommand]
        private async Task LoadDataAsync()
        {
            if (IsBusy) return;

            IsBusy = true;
            try
            {
                var dashboardData = await _apiClient.GetAdminDashboardAsync();
                if (dashboardData != null)
                {
                    Stats = dashboardData;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load dashboard data: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task GoToUsersAsync()
        {
            await Shell.Current.GoToAsync("admin/users");
        }

        [RelayCommand]
        private async Task GoToPropertiesAsync()
        {
            await Shell.Current.GoToAsync("admin/properties");

        }

        [RelayCommand]
        private async Task GoToReportsAsync()
        {
            await Shell.Current.DisplayAlert("Coming Soon", "The detailed reports feature is not yet implemented.", "OK");
        }

        [RelayCommand]
        private async Task GoToSettingsAsync()
        {
            await Shell.Current.DisplayAlert("Coming Soon", "The settings feature is not yet implemented.", "OK");
        }
    }
}