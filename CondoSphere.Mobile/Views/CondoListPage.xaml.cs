using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class CondoListPage : ContentPage
{
    private readonly CondoListViewModel _viewModel;

    public CondoListPage(CondoListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _viewModel = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel?.LoadDataCommand?.Execute(null);
    }
}