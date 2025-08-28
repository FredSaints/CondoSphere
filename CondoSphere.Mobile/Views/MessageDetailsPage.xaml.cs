using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class MessageDetailsPage : ContentPage
{
    public MessageDetailsPage(MessageDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}