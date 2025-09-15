using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Mobile.Services;
using Microsoft.Maui.Storage;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CondoSphere.Mobile.ViewModels
{
    [QueryProperty(nameof(CondoId), "CondoId")]
    public partial class AddExpenseViewModel : ObservableObject
    {
        private readonly ApiClient _apiClient;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private int condoId;

        [ObservableProperty]
        private string title;
        [ObservableProperty]
        private string description;
        [ObservableProperty]
        private decimal amount;
        [ObservableProperty]
        private DateTime expenseDate = DateTime.Today;

        public ObservableCollection<FileResult> Attachments { get; } = new();

        public AddExpenseViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [RelayCommand]
        private async Task PickFilesAsync()
        {
            try
            {
                var results = await FilePicker.PickMultipleAsync();
                if (results != null)
                {
                    foreach (var result in results)
                    {
                        Attachments.Add(result);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to pick files: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        private void RemoveFile(FileResult file)
        {
            if (file != null && Attachments.Contains(file))
            {
                Attachments.Remove(file);
            }
        }

        [RelayCommand]
        private async Task SaveExpenseAsync()
        {
            if (string.IsNullOrWhiteSpace(Title) || Amount <= 0)
            {
                await Shell.Current.DisplayAlert("Validation Error", "Please provide a valid title and amount.", "OK");
                return;
            }

            if (IsBusy) return;

            IsBusy = true;
            try
            {
                var dto = new CreateExpenseRequest
                {
                    CondominiumId = this.CondoId,
                    Title = this.Title,
                    Description = this.Description,
                    Amount = this.Amount,
                    ExpenseDate = this.ExpenseDate,
                    AttachmentFiles = new System.Collections.Generic.List<FileResult>(Attachments)
                };

                var (success, message) = await _apiClient.CreateExpenseAsync(dto);

                if (success)
                {
                    await Shell.Current.DisplayAlert("Success", message, "OK");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", message, "OK");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}