using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class QuotaDetailsPage : ContentPage
{
    public QuotaDetailsPage(QuotaDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        System.Diagnostics.Debug.WriteLine("[DEBUG] QuotaDetailsPage constructor called");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        System.Diagnostics.Debug.WriteLine("[DEBUG] QuotaDetailsPage OnAppearing called");
    }
}