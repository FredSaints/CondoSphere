using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class InterventionDetailsPage : ContentPage
{
    public InterventionDetailsPage(InterventionDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}