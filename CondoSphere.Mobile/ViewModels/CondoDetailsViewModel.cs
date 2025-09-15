using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Mobile.Services;
using System.Collections.ObjectModel;

namespace CondoSphere.Mobile.ViewModels
{

    [QueryProperty(nameof(Condo), "Condo")]
    public partial class CondoDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private CondominiumDto condo;

        [ObservableProperty]
        private OccurrenceDto selectedOccurrence;

        [ObservableProperty]
        private bool isBusy;

        public ObservableCollection<OccurrenceDto> OpenOccurrences { get; } = new();

        private readonly ApiClient _apiClient;

        public CondoDetailsViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        // This method is called automatically when the "Condo" property is set by navigation
        partial void OnCondoChanged(CondominiumDto value)
        {
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            if (Condo == null || IsBusy) return;

            IsBusy = true;
            try
            {
                OpenOccurrences.Clear();
                var occurrences = await _apiClient.GetOccurrencesForCondominiumAsync(Condo.Id);
                if (occurrences != null)
                {
                    foreach (var occ in occurrences)
                    {
                        OpenOccurrences.Add(occ);
                    }
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task GoToOccurrenceDetailsAsync(OccurrenceDto occurrence)
        {
            if (occurrence == null)
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG] GoToOccurrenceDetailsAsync called with null occurrence");
                return;
            }

            System.Diagnostics.Debug.WriteLine($"[DEBUG] GoToOccurrenceDetailsAsync → Occurrence: {occurrence.Title} (Id={occurrence.Id})");

            try
            {
                ShellDebugHelper.LogShellState("Before navigating to condos/occurrences/details");

                var sw = System.Diagnostics.Stopwatch.StartNew();
                await Shell.Current.GoToAsync("///condos/occurrences/details", new Dictionary<string, object>
                {
                    ["Occurrence"] = occurrence
                });
                sw.Stop();

                System.Diagnostics.Debug.WriteLine($"[DEBUG] Navigation to condos/occurrences/details completed in {sw.ElapsedMilliseconds} ms");
                ShellDebugHelper.LogShellState("After navigating to condos/occurrences/details");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Navigation to condos/occurrences/details FAILED: {ex}");
                await Shell.Current.DisplayAlert("Navigation Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        private async Task ManageUnitsAsync()
        {
            if (Condo == null) return;

            await Shell.Current.GoToAsync($"condos/details/units?CondoId={Condo.Id}");
        }

        [RelayCommand]
        private async Task SendNoticeAsync()
        {
            if (Condo == null) return;
            await Shell.Current.GoToAsync($"condos/details/sendnotice?CondoId={Condo.Id}");
        }

        [RelayCommand]
        private async Task AddExpenseAsync()
        {
            if (Condo == null) return;
            await Shell.Current.GoToAsync($"condos/details/addexpense?CondoId={Condo.Id}");
        }

        [RelayCommand]
        private async Task ViewReportsAsync()
        {
            await Shell.Current.DisplayAlert("Coming Soon", "Detailed property reports are not yet available in the mobile app.", "OK");
        }
    }
}