using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Mobile.Services;
using System.Collections.ObjectModel;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class DocumentsViewModel : ObservableObject
    {
        private readonly ApiClient _apiClient;

        private List<DocumentDto> _fullDocumentList = new();

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string selectedCategory = "All Files";

        public ObservableCollection<DocumentDto> Documents { get; } = new();

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
                _fullDocumentList.Clear();
                Documents.Clear();
                SelectedCategory = "All Files";

                var docs = await _apiClient.GetMyDocumentsAsync();
                if (docs != null)
                {
                    _fullDocumentList.AddRange(docs);
                    ApplyFilter();
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private void FilterByCategory(string category)
        {
            SelectedCategory = category;
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            Documents.Clear();

            if (string.IsNullOrEmpty(SelectedCategory) || SelectedCategory == "All Files")
            {
                foreach (var doc in _fullDocumentList)
                {
                    Documents.Add(doc);
                }
            }
            else
            {
                var filteredDocs = _fullDocumentList.Where(d => d.Category == SelectedCategory);
                foreach (var doc in filteredDocs)
                {
                    Documents.Add(doc);
                }
            }
        }

        [RelayCommand]
        private async Task OpenDocumentAsync(DocumentDto document)
        {
            if (document == null || IsBusy) return;

            IsBusy = true;
            try
            {
                var downloadUrl = $"{ApiClient.WebBaseUrl}/portal/documents/{document.Id}/view";

                await Launcher.OpenAsync(downloadUrl);
            }
            catch (System.Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Could not open document: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}