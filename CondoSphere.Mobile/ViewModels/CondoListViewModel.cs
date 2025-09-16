using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Mobile.Services;
using System.Collections.ObjectModel;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class CondoListViewModel : BaseViewModel
    {
        private readonly ApiClient _apiClient;

        private List<CondominiumDto> _fullCondoList = new();

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string searchText;

        public ObservableCollection<CondominiumDto> Condominiums { get; } = new();

        public CondoListViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [RelayCommand]
        private async Task LoadDataAsync()
        {
            if (IsBusy) return;

            IsBusy = true;
            try
            {
                _fullCondoList.Clear();
                Condominiums.Clear();
                SearchText = string.Empty;

                var condos = await _apiClient.GetMyManagedCondominiumsAsync();
                if (condos != null)
                {
                    _fullCondoList.AddRange(condos);
                    ApplyFilter();
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        partial void OnSearchTextChanged(string value)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            Condominiums.Clear();

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                foreach (var condo in _fullCondoList)
                {
                    Condominiums.Add(condo);
                }
            }
            else
            {
                var filteredCondos = _fullCondoList.Where(c =>
                    c.Name.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase) ||
                    c.Address.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase));

                foreach (var condo in filteredCondos)
                {
                    Condominiums.Add(condo);
                }
            }
        }

        [RelayCommand]
        private async Task GoToDetailsAsync(CondominiumDto condo)
        {
            if (condo == null)
            {
                return;
            }

            await Shell.Current.GoToAsync("condos/details", new Dictionary<string, object>
            {
                { "Condo", condo }
            });
        }
    }
}