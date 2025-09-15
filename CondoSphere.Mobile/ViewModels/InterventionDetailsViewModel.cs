using CommunityToolkit.Mvvm.ComponentModel;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Mobile.Services;

namespace CondoSphere.Mobile.ViewModels
{
    [QueryProperty(nameof(SelectedTask), "Intervention")]
    public partial class InterventionDetailsViewModel : ObservableObject
    {
        private readonly ApiClient _apiClient;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private InterventionDto selectedTask;

        [ObservableProperty]
        private OccurrenceDto occurrenceDetails;

        public InterventionDetailsViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        async partial void OnSelectedTaskChanged(InterventionDto value)
        {
            if (value != null)
            {
                await LoadDetailsAsync();
            }
        }

        private async Task LoadDetailsAsync()
        {
            if (IsBusy || SelectedTask == null || SelectedTask.OccurrenceId == 0)
                return;

            IsBusy = true;
            try
            {
                var occurrence = await _apiClient.GetOccurrenceDetailsAsync(SelectedTask.OccurrenceId);
                OccurrenceDetails = occurrence;
            }
            catch (System.Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load task details: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}