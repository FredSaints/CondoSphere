using CommunityToolkit.Mvvm.ComponentModel;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class ShellViewModel : ObservableObject
    {
        [ObservableProperty] private bool isResident;
        [ObservableProperty] private bool isManager;
        [ObservableProperty] private bool isAdmin;

        // New: explicit auth flags
        [ObservableProperty] private bool isAuthenticated;
        [ObservableProperty] private bool isUnauthenticated = true; // default

        public ShellViewModel()
        {
            // IMPORTANT: do NOT auto-load roles/token here
            // Keep the app unauthenticated on cold start.
        }

        // Call this ONLY after a successful login
        public void ApplyRoles(IEnumerable<string> roles)
        {
            IsResident = roles.Contains("CondoResident");
            IsManager = roles.Contains("CondoManager");
            IsAdmin = roles.Contains("CompanyAdmin");

            IsAuthenticated = true;
            IsUnauthenticated = false;

            System.Diagnostics.Debug.WriteLine(
                $"[ShellViewModel] Roles applied → Resident={IsResident}, Manager={IsManager}, Admin={IsAdmin}");
        }

        // Call this on logout (or if login fails)
        public void ResetAuth()
        {
            IsResident = IsManager = IsAdmin = false;
            IsAuthenticated = false;
            IsUnauthenticated = true;
        }
    }
}
