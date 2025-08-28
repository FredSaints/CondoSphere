using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class ComposeMessagePage : ContentPage
{
    private readonly ComposeMessageViewModel _viewModel;

    public ComposeMessagePage(ComposeMessageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadContactsAsync();
    }
}