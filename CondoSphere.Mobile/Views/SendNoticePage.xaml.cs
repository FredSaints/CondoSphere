using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class SendNoticePage : ContentPage
{
    public SendNoticePage(SendNoticeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}