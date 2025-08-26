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

        // Listen for successful login
        WeakReferenceMessenger.Default.Register<LoginSuccessMessage>(this, async (_, msg) =>
        {
            // Reuse the existing VM if you set it in XAML, otherwise create one:
            var vm = BindingContext as ShellViewModel ?? new ShellViewModel();
            BindingContext = vm;

            // Load roles from the *fresh* token and apply
            var token = await TokenStorage.GetTokenAsync();
            var roles = JwtHelpers.ExtractRoles(token); // implement this helper to parse claims
            vm.ApplyRoles(roles);

            var home = vm.IsManager ? "//manager/condos"
                     : vm.IsAdmin ? "//admin/dashboard"
                     : vm.IsResident ? "//resident/portal"
                     : "///auth/login";

            await Shell.Current.GoToAsync(home, false);
        });
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Always clear token so the user must login again
        await TokenStorage.RemoveTokenAsync();   // <-- make this async (see #3)

        // Reset ShellViewModel to "unauthenticated"
        if (BindingContext is ShellViewModel vm)
            vm.ResetAuth();                      // <-- use your helper

        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            // IMPORTANT: your login page lives under the TabBar "auth" => route is "auth/login"
            await Shell.Current.GoToAsync("///auth/login", false);   // <-- was "///login"
        });
    }
}
