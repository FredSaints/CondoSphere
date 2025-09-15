using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class UnitListPage : ContentPage
{
    public UnitListPage(UnitListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}