using CommunityToolkit.Mvvm.Messaging;
using CondoSphere.Mobile.Messages;
using CondoSphere.Mobile.Services;
using CondoSphere.Mobile.ViewModels;
using CondoSphere.Mobile.Views;

namespace CondoSphere.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Routes NOT in the visual tree:
        Routing.RegisterRoute("condos/details", typeof(CondoDetailsPage));
        Routing.RegisterRoute("condos/occurrences/details", typeof(ManagerOccurrenceDetailsPage));
        Routing.RegisterRoute("condos/occurrences/create", typeof(CreateOccurrencePage));
        Routing.RegisterRoute("quotas/details", typeof(QuotaDetailsPage));
        Routing.RegisterRoute(nameof(MessageDetailsPage), typeof(MessageDetailsPage));
        Routing.RegisterRoute(nameof(ComposeMessagePage), typeof(ComposeMessagePage));
        Routing.RegisterRoute("profile/changepassword", typeof(ChangePasswordPage));
        Routing.RegisterRoute("profile/edit", typeof(EditProfilePage));
        Routing.RegisterRoute("admin/users", typeof(UserListAdminPage));
        Routing.RegisterRoute("admin/properties", typeof(PropertyListAdminPage));
        Routing.RegisterRoute("condos/details/units", typeof(UnitListPage));
        Routing.RegisterRoute("condos/details/sendnotice", typeof(SendNoticePage));
        Routing.RegisterRoute("condos/details/addexpense", typeof(AddExpensePage));
        Routing.RegisterRoute("employee/taskdetails", typeof(InterventionDetailsPage));
        Routing.RegisterRoute("profile", typeof(ProfilePage));

        // Listen for successful login
        WeakReferenceMessenger.Default.Register<LoginSuccessMessage>(this, async (_, msg) =>
        {
            var vm = BindingContext as ShellViewModel ?? new ShellViewModel();
            BindingContext = vm;

            var token = await TokenStorage.GetTokenAsync();
            var roles = JwtHelpers.ExtractRoles(token);
            vm.ApplyRoles(roles);

            var home = vm.IsManager ? "//manager/condos"
                     : vm.IsEmployee ? "//employee/tasks"
                     : vm.IsAdmin ? "//admin/dashboard"
                     : vm.IsResident ? "//resident/portal"
                     : "///auth/login";

            await Shell.Current.GoToAsync(home, false);
        });
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await TokenStorage.RemoveTokenAsync();

        // Reset ShellViewModel to "unauthenticated"
        if (BindingContext is ShellViewModel vm)
            vm.ResetAuth();

        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            await Shell.Current.GoToAsync("///auth/login", false);
        });
    }
}
