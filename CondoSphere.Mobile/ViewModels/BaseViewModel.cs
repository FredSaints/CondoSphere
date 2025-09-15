using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task GoToProfileAsync()
        {
            await Shell.Current.GoToAsync("profile");
        }
    }
}