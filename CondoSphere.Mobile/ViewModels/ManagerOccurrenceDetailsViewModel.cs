using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Mobile.Services;
using System.Collections.ObjectModel;

namespace CondoSphere.Mobile.ViewModels
{
    [QueryProperty(nameof(Occurrence), "Occurrence")]
    public partial class ManagerOccurrenceDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private OccurrenceDto occurrence;

        [ObservableProperty]
        private bool isBusy;

        // Use the Mobile.Services DTO to match ApiClient and XAML
        public ObservableCollection<InterventionDto> Interventions { get; } = new();

        private readonly ApiClient _apiClient;

        public ManagerOccurrenceDetailsViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
            System.Diagnostics.Debug.WriteLine($"[DEBUG] ManagerOccurrenceDetailsViewModel constructor called");
        }

        partial void OnOccurrenceChanged(OccurrenceDto value)
        {
            System.Diagnostics.Debug.WriteLine($"[DEBUG] OnOccurrenceChanged called with: {value?.Title ?? "null"}");
            if (value != null)
            {
                _ = LoadDataAsync();
            }
        }

        public async Task LoadDataAsync()
        {
            System.Diagnostics.Debug.WriteLine($"[DEBUG] LoadDataAsync called. Occurrence: {Occurrence?.Title ?? "null"}, IsBusy: {IsBusy}");

            if (Occurrence == null || IsBusy)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] LoadDataAsync early return");
                return;
            }

            IsBusy = true;
            try
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Loading interventions for occurrence {Occurrence.Id}");
                Interventions.Clear();
                var interventions = await _apiClient.GetInterventionsForOccurrenceAsync(Occurrence.Id);
                if (interventions != null)
                {
                    foreach (var intervention in interventions)
                    {
                        Interventions.Add(intervention);
                    }
                }
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Loaded {Interventions.Count} interventions");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] LoadDataAsync exception: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", $"Failed to load interventions: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
                System.Diagnostics.Debug.WriteLine($"[DEBUG] LoadDataAsync completed");
            }
        }

        [RelayCommand]
        private async Task GoBackAsync()
        {
            System.Diagnostics.Debug.WriteLine($"[DEBUG] GoBackAsync called");
            ShellDebugHelper.LogShellState("Before GoBackAsync navigation");

            try
            {
                await Shell.Current.GoToAsync("..");
                System.Diagnostics.Debug.WriteLine($"[DEBUG] GoBackAsync navigation completed");
                ShellDebugHelper.LogShellState("After GoBackAsync navigation");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] GoBackAsync failed: {ex.Message}");
                await Shell.Current.DisplayAlert("Navigation Error", ex.Message, "OK");
            }
        }
    }
}
