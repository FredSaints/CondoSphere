using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class CondoDetailsPage : ContentPage
{
    public CondoDetailsPage(CondoDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        if (Content.FindByName<CollectionView>("occurrencesCollectionView") is CollectionView cv)
        {
            cv.SelectedItem = null;
        }
    }
}