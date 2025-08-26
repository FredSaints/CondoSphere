using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class ResidentPortalPage : ContentPage
{
    private readonly ResidentPortalViewModel _viewModel;

    public ResidentPortalPage(ResidentPortalViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _viewModel = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Load data every time the page appears
        _viewModel.LoadDataCommand.Execute(null);
    }
}