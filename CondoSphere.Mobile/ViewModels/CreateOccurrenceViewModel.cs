using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Mobile.Services;
using System.Collections.ObjectModel;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class CreateOccurrenceViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
        private string title;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
        private string description;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
        private UnitDto selectedUnit;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
        private bool isBusy;

        // This holds the actual file data after picking
        private FileResult? _selectedImageFile;

        // This is for the UI to bind to for the image preview
        [ObservableProperty]
        private ImageSource? imageFileSource;

        public bool ImageIsVisible => ImageFileSource != null;

        public ObservableCollection<UnitDto> UserUnits { get; } = new();

        private readonly ApiClient _apiClient;

        public CreateOccurrenceViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task LoadUserUnitsAsync()
        {
            if (UserUnits.Any() || IsBusy) return;

            IsBusy = true;
            try
            {
                var units = await _apiClient.GetMyUnitsAsync();
                if (units != null)
                {
                    UserUnits.Clear();
                    foreach (var unit in units)
                    {
                        UserUnits.Add(unit);
                    }
                    // Default to the first unit in the list
                    SelectedUnit = UserUnits.FirstOrDefault();
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task SelectPhotoAsync()
        {
            if (IsBusy) return;
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please pick a photo"
                });

                if (result != null)
                {
                    _selectedImageFile = result;

                    // Create a source for the UI to preview the image
                    var stream = await result.OpenReadAsync();
                    ImageFileSource = ImageSource.FromStream(() => stream);
                    OnPropertyChanged(nameof(ImageIsVisible)); // Notify UI to show/hide the Image control
                }
            }
            catch (Exception ex)
            {
                // This can happen if permissions are not configured correctly
                await Shell.Current.DisplayAlert("Error", $"Could not select photo: {ex.Message}", "OK");
            }
        }

        private bool CanSubmit() =>
            !string.IsNullOrWhiteSpace(Title) &&
            !string.IsNullOrWhiteSpace(Description) &&
            SelectedUnit != null &&
            !IsBusy;

        [RelayCommand(CanExecute = nameof(CanSubmit))]
        private async Task SubmitAsync()
        {
            IsBusy = true;
            try
            {
                var newOccurrence = new CreateOccurrenceRequest
                {
                    Title = Title,
                    Description = Description,
                    UnitId = SelectedUnit.Id,
                    ImageFile = _selectedImageFile // Pass the selected file (can be null)
                };

                var success = await _apiClient.CreateOccurrenceAsync(newOccurrence);

                if (success)
                {
                    await Shell.Current.DisplayAlert("Success", "Your occurrence has been reported.", "OK");
                    await Shell.Current.GoToAsync(".."); // Go back to the previous page
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Failed to submit occurrence. Please try again.", "OK");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}