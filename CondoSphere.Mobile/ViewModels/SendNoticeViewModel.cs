using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Mobile.Services;

namespace CondoSphere.Mobile.ViewModels
{
    [QueryProperty(nameof(CondoId), "CondoId")]
    public partial class SendNoticeViewModel : ObservableObject
    {
        private readonly ApiClient _apiClient;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private int condoId;

        [ObservableProperty]
        private string subject;

        [ObservableProperty]
        private string message;

        public SendNoticeViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [RelayCommand]
        private async Task SendNoticeAsync()
        {
            if (string.IsNullOrWhiteSpace(Subject) || string.IsNullOrWhiteSpace(Message))
            {
                await Shell.Current.DisplayAlert("Validation Error", "Please fill in both the subject and the message.", "OK");
                return;
            }

            if (IsBusy) return;

            IsBusy = true;
            try
            {
                var dto = new AnnouncementDto { Subject = this.Subject, Message = this.Message };
                var (success, responseMessage) = await _apiClient.SendAnnouncementAsync(CondoId, dto);

                if (success)
                {
                    await Shell.Current.DisplayAlert("Success", responseMessage, "OK");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", responseMessage, "OK");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}