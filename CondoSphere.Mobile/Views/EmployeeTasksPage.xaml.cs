using CondoSphere.Mobile.ViewModels;
namespace CondoSphere.Mobile.Views;
public partial class EmployeeTasksPage : ContentPage
{
    private readonly EmployeeTasksViewModel _viewModel;
    public EmployeeTasksPage(EmployeeTasksViewModel vm)
    {
        InitializeComponent();
        _viewModel = vm;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadTasksCommand.Execute(null);
    }
}