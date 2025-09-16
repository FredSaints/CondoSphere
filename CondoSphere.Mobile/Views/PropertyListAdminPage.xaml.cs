using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class PropertyListAdminPage : ContentPage
{
    private readonly PropertyListAdminViewModel _viewModel;
    public PropertyListAdminPage(PropertyListAdminViewModel vm)
    {
        InitializeComponent();
        _viewModel = vm;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadPropertiesCommand.Execute(null);
    }
}