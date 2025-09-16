using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Mobile.Services;
using System.Collections.ObjectModel;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class PropertyListAdminViewModel : ObservableObject
    {
        private readonly ApiClient _apiClient;

        [ObservableProperty]
        private bool isBusy;

        public ObservableCollection<CondominiumDto> Properties { get; } = new();

        public PropertyListAdminViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [RelayCommand]
        private async Task LoadPropertiesAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Properties.Clear();

                var propertyList = await _apiClient.GetAllCondosForAdminAsync();
                if (propertyList != null)
                {
                    foreach (var prop in propertyList)
                    {
                        Properties.Add(prop);
                    }
                }
            }
            catch (System.Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load properties: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}