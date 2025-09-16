using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class ManagerOccurrenceDetailsPage : ContentPage
{
    private readonly ManagerOccurrenceDetailsViewModel _viewModel;

    public ManagerOccurrenceDetailsPage(ManagerOccurrenceDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _viewModel = vm;

        System.Diagnostics.Debug.WriteLine($"[DEBUG] ManagerOccurrenceDetailsPage constructor called");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        System.Diagnostics.Debug.WriteLine($"[DEBUG] ManagerOccurrenceDetailsPage OnAppearing called");
        ShellDebugHelper.LogShellState("ManagerOccurrenceDetailsPage OnAppearing");
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        System.Diagnostics.Debug.WriteLine($"[DEBUG] ManagerOccurrenceDetailsPage OnNavigatedTo called");
        ShellDebugHelper.LogShellState("ManagerOccurrenceDetailsPage OnNavigatedTo");
    }
}
