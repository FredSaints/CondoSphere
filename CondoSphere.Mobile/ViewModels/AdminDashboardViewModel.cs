using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Reports;
using CondoSphere.Mobile.Services;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class AdminDashboardViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private AdminDashboardDto stats;

        private readonly ApiClient _apiClient;

        public AdminDashboardViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
            // Initialize with an empty object to avoid null reference issues in XAML
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
    }
}