using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class UserListAdminPage : ContentPage
{
    private readonly UserListAdminViewModel _viewModel;
    public UserListAdminPage(UserListAdminViewModel vm)
    {
        InitializeComponent();
        _viewModel = vm;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadUsersCommand.Execute(null);
    }
}