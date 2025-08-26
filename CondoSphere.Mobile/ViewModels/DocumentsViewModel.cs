using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Mobile.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class DocumentsViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isBusy;

        public ObservableCollection<DocumentDto> Documents { get; } = new();

        private readonly ApiClient _apiClient;

        public DocumentsViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [RelayCommand]
        private async Task LoadDataAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            try
            {
                Documents.Clear();
                var docs = await _apiClient.GetMyDocumentsAsync();
                if (docs != null)
                {
                    foreach (var doc in docs)
                    {
                        Documents.Add(doc);
                    }
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task OpenDocumentAsync(DocumentDto document)
        {
            if (document == null) return;
            var downloadUrl = $"{ApiClient.ApiBaseUrl}/api/documents/{document.Id}/download";

            try
            {
                await Launcher.OpenAsync(downloadUrl);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Could not open document: {ex.Message}", "OK");
            }
        }
    }
}