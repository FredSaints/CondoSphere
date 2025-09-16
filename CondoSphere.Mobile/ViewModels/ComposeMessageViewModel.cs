using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Mobile.Services;
using System.Collections.ObjectModel;

namespace CondoSphere.Mobile.ViewModels
{
    [QueryProperty(nameof(ReceiverId), "ReceiverId")]
    [QueryProperty(nameof(Subject), "Subject")]
    [QueryProperty(nameof(CondominiumId), "CondominiumId")]
    public partial class ComposeMessageViewModel : ObservableObject
    {
        [ObservableProperty]
        private int receiverId;

        [ObservableProperty]
        private string subject = string.Empty;

        [ObservableProperty]
        private string content = string.Empty;

        [ObservableProperty]
        private int? condominiumId;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private SimpleUserDto selectedContact;

        public ObservableCollection<SimpleUserDto> Contacts { get; } = new();

        private readonly ApiClient _apiClient;

        public ComposeMessageViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task LoadContactsAsync()
        {
            if (IsBusy) return;

            IsBusy = true;
            try
            {
                Contacts.Clear();
                var contacts = await _apiClient.GetContactsAsync();

                if (contacts != null)
                {
                    foreach (var contact in contacts)
                    {
                        Contacts.Add(contact);
                    }

                    // Pre-select contact if ReceiverId was provided
                    if (ReceiverId > 0)
                    {
                        SelectedContact = Contacts.FirstOrDefault(c => c.Id == ReceiverId);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load contacts: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task SendMessageAsync()
        {
            if (IsBusy) return;

            if (SelectedContact == null)
            {
                await Shell.Current.DisplayAlert("Validation Error", "Please select a recipient.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Subject))
            {
                await Shell.Current.DisplayAlert("Validation Error", "Please enter a subject.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Content))
            {
                await Shell.Current.DisplayAlert("Validation Error", "Please enter a message.", "OK");
                return;
            }

            IsBusy = true;
            try
            {
                var dto = new SendMessageDto
                {
                    ReceiverId = SelectedContact.Id,
                    Subject = Subject.Trim(),
                    Content = Content.Trim(),
                    CondominiumId = CondominiumId
                };

                var success = await _apiClient.SendMessageAsync(dto);

                if (success)
                {
                    await Shell.Current.DisplayAlert("Success", "Message sent successfully!", "OK");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Failed to send message. Please try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to send message: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task CancelAsync()
        {
            if (!string.IsNullOrWhiteSpace(Subject) || !string.IsNullOrWhiteSpace(Content))
            {
                var discard = await Shell.Current.DisplayAlert("Discard Message", "Are you sure you want to discard this message?", "Discard", "Continue Editing");
                if (!discard) return;
            }

            await Shell.Current.GoToAsync("..");
        }

        partial void OnSelectedContactChanged(SimpleUserDto value)
        {
            if (value != null)
            {
                ReceiverId = value.Id;
            }
        }
    }
}