using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Mobile.Services;
using CondoSphere.Mobile.Views;
using System.Collections.ObjectModel;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class CondoListViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isBusy;

        public ObservableCollection<CondominiumDto> Condominiums { get; } = new();

        private readonly ApiClient _apiClient;

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
                Condominiums.Clear();
                var condos = await _apiClient.GetMyManagedCondominiumsAsync();
                if (condos != null)
                {
                    foreach (var condo in condos)
                    {
                        Condominiums.Add(condo);
                    }
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task GoToDetailsAsync(CondominiumDto condo)
        {
            if (condo == null)
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] GoToDetailsAsync called with null condo");
                return;
            }

            System.Diagnostics.Debug.WriteLine($"[DEBUG] GoToDetailsAsync → Condo: {condo.Name} (Id={condo.Id})");

            try
            {
                ShellDebugHelper.LogShellState("Before navigating to condos/details");

                var sw = System.Diagnostics.Stopwatch.StartNew();
                await Shell.Current.GoToAsync("///condos/details", new Dictionary<string, object>
                {
                    ["Condo"] = condo
                });
                sw.Stop();

                System.Diagnostics.Debug.WriteLine($"[DEBUG] Navigation to condos/details completed in {sw.ElapsedMilliseconds} ms");
                ShellDebugHelper.LogShellState("After navigating to condos/details");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Navigation to condos/details FAILED: {ex}");
                await Shell.Current.DisplayAlert("Navigation Error", ex.Message, "OK");
            }
        }
    }
}