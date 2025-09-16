using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Mobile.Services;
using Microsoft.Maui.Media;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CondoSphere.Mobile.ViewModels
{
    [QueryProperty(nameof(CurrentUserProfile), "UserProfile")]
    public partial class EditProfileViewModel : ObservableObject
    {
        private readonly ApiClient _apiClient;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private UserProfileDto currentUserProfile;

        [ObservableProperty]
        private string firstName;
        [ObservableProperty]
        private string lastName;
        [ObservableProperty]
        private string phoneNumber;
        [ObservableProperty]
        private ImageSource profileImageSource;

        private FileResult newImageFile;

        public EditProfileViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        partial void OnCurrentUserProfileChanged(UserProfileDto value)
        {
            if (value != null)
            {
                FirstName = value.FirstName;
                LastName = value.LastName;
                PhoneNumber = value.PhoneNumber;
                ProfileImageSource = ImageSource.FromUri(new System.Uri(value.ProfilePictureUrl ?? "default_profile.png"));
            }
        }

        [RelayCommand]
        private async Task PickPhotoAsync()
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please pick a photo"
                });

                if (result != null)
                {
                    newImageFile = result;
                    var stream = await result.OpenReadAsync();
                    ProfileImageSource = ImageSource.FromStream(() => stream);
                }
            }
            catch (System.Exception ex)
            {
                await Shell.Current.DisplayAlert("Permission Error", $"Could not select photo: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        private async Task SaveProfileAsync()
        {
            if (IsBusy) return;

            IsBusy = true;
            try
            {
                var dto = new UpdateProfileDto
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    PhoneNumber = this.PhoneNumber,
                    ProfilePictureUrl = this.CurrentUserProfile.ProfilePictureUrl
                };

                var (success, message, newToken) = await _apiClient.UpdateProfileAsync(dto, newImageFile);

                if (success && !string.IsNullOrEmpty(newToken))
                {
                    await TokenStorage.SaveTokenAsync(newToken);
                    await Shell.Current.DisplayAlert("Success", "Profile updated successfully.", "OK");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Update Failed", message, "OK");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}