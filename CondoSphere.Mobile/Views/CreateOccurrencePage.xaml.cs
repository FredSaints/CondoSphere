using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class CreateOccurrencePage : ContentPage
{
    private readonly CreateOccurrenceViewModel _viewModel;

    public CreateOccurrencePage(CreateOccurrenceViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _viewModel = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadUserUnitsAsync();
    }
}