using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Mobile.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace CondoSphere.Mobile.ViewModels
{
    [QueryProperty(nameof(CondoId), "CondoId")]
    public partial class UnitListViewModel : ObservableObject
    {
        private readonly ApiClient _apiClient;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private int condoId;

        public ObservableCollection<UnitDto> Units { get; } = new();

        public UnitListViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        async partial void OnCondoIdChanged(int value)
        {
            if (value > 0)
            {
                await LoadUnitsAsync();
            }
        }

        [RelayCommand]
        private async Task LoadUnitsAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Units.Clear();
                var unitList = await _apiClient.GetUnitsForCondominiumAsync(CondoId);
                if (unitList != null)
                {
                    foreach (var unit in unitList.OrderBy(u => u.Identifier))
                    {
                        Units.Add(unit);
                    }
                }
            }
            catch (System.Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load units: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}