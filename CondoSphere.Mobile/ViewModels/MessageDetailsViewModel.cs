using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Mobile.Services;
using CondoSphere.Mobile.Views;

namespace CondoSphere.Mobile.ViewModels
{
    [QueryProperty(nameof(Message), "Message")]
    public partial class MessageDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private MessageDto message;

        [ObservableProperty]
        private bool isBusy;

        private readonly ApiClient _apiClient;

        public MessageDetailsViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        partial void OnMessageChanged(MessageDto value)
        {
            if (value != null && !value.IsRead)
            {
                // Mark as read when viewing
                _ = Task.Run(async () => await _apiClient.MarkMessageAsReadAsync(value.Id));
            }
        }

        [RelayCommand]
        private async Task ReplyAsync()
        {
            if (Message == null) return;

            var replySubject = Message.Subject.StartsWith("Re:") ? Message.Subject : $"Re: {Message.Subject}";

            var navigationParams = new Dictionary<string, object>
            {
                { "ReceiverId", Message.SenderId },
                { "Subject", replySubject }
            };

            if (Message.CondominiumId.HasValue)
            {
                navigationParams.Add("CondominiumId", Message.CondominiumId.Value);
            }

            await Shell.Current.GoToAsync($"{nameof(ComposeMessagePage)}", navigationParams);
        }

        [RelayCommand]
        private async Task BackToMessagesAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}