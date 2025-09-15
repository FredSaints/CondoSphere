using CondoSphere.Mobile.ViewModels;

namespace CondoSphere.Mobile.Views;

public partial class EditProfilePage : ContentPage
{
	public EditProfilePage(EditProfileViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}