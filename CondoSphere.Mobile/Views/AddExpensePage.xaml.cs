using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class AddExpensePage : ContentPage
{
    public AddExpensePage(AddExpenseViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}