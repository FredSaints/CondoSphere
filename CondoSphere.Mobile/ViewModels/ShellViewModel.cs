using CommunityToolkit.Mvvm.ComponentModel;

namespace CondoSphere.Mobile.ViewModels
{
    public partial class ShellViewModel : ObservableObject
    {
        [ObservableProperty] private bool isResident;
        [ObservableProperty] private bool isManager;
        [ObservableProperty] private bool isAdmin;
        [ObservableProperty] private bool isEmployee;

        // New: explicit auth flags
        [ObservableProperty] private bool isAuthenticated;
        [ObservableProperty] private bool isUnauthenticated = true;

        public ShellViewModel()
        {
        }

        // Call this ONLY after a successful login
        public void ApplyRoles(IEnumerable<string> roles)
        {
            IsResident = roles.Contains("CondoResident");
            IsManager = roles.Contains("CondoManager");
            IsAdmin = roles.Contains("CompanyAdmin");
            IsEmployee = roles.Contains("Employee");

            IsAuthenticated = true;
            IsUnauthenticated = false;

            System.Diagnostics.Debug.WriteLine(
                $"[ShellViewModel] Roles applied → Resident={IsResident}, Manager={IsManager}, Admin={IsAdmin}");
        }

        // Call this on logout (or if login fails)
        public void ResetAuth()
        {
            IsResident = IsManager = IsAdmin = IsEmployee = false;
            IsAuthenticated = false;
            IsUnauthenticated = true;
        }
    }
}
