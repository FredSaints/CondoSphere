using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Mobile.Services;
using System.Collections.ObjectModel;
using CondoSphere.Mobile.Views;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class MessagesViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private bool isInboxSelected = true;

        [ObservableProperty]
        private int unreadCount;

        public ObservableCollection<MessageListDto> Messages { get; } = new();

        private readonly ApiClient _apiClient;

        public MessagesViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [RelayCommand]
        private async Task LoadInboxAsync()
        {
            if (IsBusy) return;

            IsBusy = true;
            IsInboxSelected = true;

            try
            {
                Messages.Clear();
                var inbox = await _apiClient.GetInboxAsync();

                if (inbox != null)
                {
                    foreach (var message in inbox)
                    {
                        message.DisplayName = message.SenderName;
                        Messages.Add(message);
                    }
                }

                UnreadCount = Messages.Count(m => !m.IsRead);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load inbox: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task LoadSentAsync()
        {
            if (IsBusy) return;

            IsBusy = true;
            IsInboxSelected = false;

            try
            {
                Messages.Clear();
                var sent = await _apiClient.GetSentMessagesAsync();

                if (sent != null)
                {
                    foreach (var message in sent)
                    {
                        message.DisplayName = message.ReceiverName;
                        Messages.Add(message);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load sent messages: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task ViewMessageAsync(MessageListDto message)
        {
            if (message == null) return;

            try
            {
                var fullMessage = await _apiClient.GetMessageAsync(message.Id);
                if (fullMessage != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(MessageDetailsPage)}",
                        new Dictionary<string, object>
                        {
                            { "Message", fullMessage }
                        });
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load message: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        private async Task ComposeMessageAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(ComposeMessagePage)}");
        }

        [RelayCommand]
        private async Task RefreshAsync()
        {
            if (IsInboxSelected)
            {
                await LoadInboxAsync();
            }
            else
            {
                await LoadSentAsync();
            }
        }

        public async Task LoadDataAsync()
        {
            await LoadInboxAsync();
        }
    }
}