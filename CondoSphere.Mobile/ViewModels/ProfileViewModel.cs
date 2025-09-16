using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Mobile.Services;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        private readonly ApiClient _apiClient;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string fullName;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string roleAndUnit;

        [ObservableProperty]
        private string profilePictureUrl;

        public ProfileViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
            FullName = "Loading...";
            Email = "loading@email.com";
            RoleAndUnit = "Fetching details...";
            ProfilePictureUrl = "default_profile.png";
        }

        [RelayCommand]
        private async Task LoadProfileAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                var profile = await _apiClient.GetMyProfileAsync();
                if (profile != null)
                {
                    FullName = $"{profile.FirstName} {profile.LastName}";
                    Email = profile.Email;
                    // A simple way to get the primary role
                    RoleAndUnit = profile.Roles.FirstOrDefault()?.Replace("Condo", "") ?? "User";

                    // Set profile picture, using a default if none is provided by the API
                    ProfilePictureUrl = !string.IsNullOrEmpty(profile.ProfilePictureUrl)
                        ? profile.ProfilePictureUrl
                        : "default_profile.png";
                }
            }
            catch (System.Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load profile: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task SignOutAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                await TokenStorage.RemoveTokenAsync();

                if (Shell.Current.BindingContext is ShellViewModel shellVm)
                {
                    shellVm.ResetAuth();
                }

                await Shell.Current.GoToAsync("///auth/login");
            }
            catch (System.Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to sign out: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task GoToChangePasswordAsync()
        {
            await Shell.Current.GoToAsync("changepassword");
        }

        [RelayCommand]
        private async Task GoToEditProfileAsync()
        {
            var currentProfile = await _apiClient.GetMyProfileAsync();
            if (currentProfile == null)
            {
                await Shell.Current.DisplayAlert("Error", "Could not load profile data to edit.", "OK");
                return;
            }

            await Shell.Current.GoToAsync("edit", new Dictionary<string, object>
            {
                { "UserProfile", currentProfile }
            });
        }

        [RelayCommand]
        private async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}