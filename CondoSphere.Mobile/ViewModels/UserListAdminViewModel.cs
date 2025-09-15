using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Mobile.Services;
using System.Collections.ObjectModel;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class UserListAdminViewModel : ObservableObject
    {
        private readonly ApiClient _apiClient;

        [ObservableProperty]
        private bool isBusy;

        // This collection will be bound to the UI
        public ObservableCollection<UserListDto> Users { get; } = new();

        public UserListAdminViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [RelayCommand]
        private async Task LoadUsersAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Users.Clear();

                var userList = await _apiClient.GetUsersAsync();
                if (userList != null)
                {
                    foreach (var user in userList)
                    {
                        Users.Add(user);
                    }
                }
            }
            catch (System.Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load users: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}