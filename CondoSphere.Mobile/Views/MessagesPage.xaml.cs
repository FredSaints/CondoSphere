using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class MessagesPage : ContentPage
{
    private readonly MessagesViewModel _viewModel;

    public MessagesPage(MessagesViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadDataAsync();
    }
}