using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CondoSphere.Mobile.Services;
using System.Collections.ObjectModel;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class EmployeeTasksViewModel : BaseViewModel
    {
        private readonly ApiClient _apiClient;

        [ObservableProperty]
        private bool isBusy;

        public ObservableCollection<InterventionDto> Tasks { get; } = new();

        public EmployeeTasksViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [RelayCommand]
        private async Task LoadTasksAsync()
        {
            if (IsBusy) return;

            IsBusy = true;
            try
            {
                Tasks.Clear();
                var tasksList = await _apiClient.GetMyTasksAsync();
                if (tasksList != null)
                {
                    foreach (var task in tasksList)
                    {
                        Tasks.Add(task);
                    }
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task GoToTaskDetailsAsync(InterventionDto task)
        {
            if (task == null) return;
            await Shell.Current.GoToAsync("employee/taskdetails", new Dictionary<string, object>
            {
                { "Intervention", task }
            });
        }
    }
}