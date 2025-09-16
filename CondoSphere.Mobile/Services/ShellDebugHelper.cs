public static class ShellDebugHelper
{
    public static void LogShellState(string label)
    {
        try
        {
            var shell = Shell.Current;
            if (shell == null)
            {
                System.Diagnostics.Debug.WriteLine("[SHELL DEBUG] Shell.Current is null");
                return;
            }

            var loc = shell.CurrentState?.Location?.ToString() ?? "(unknown)";
            var stack = shell.Navigation?.NavigationStack?.ToList() ?? new List<Page>();

            System.Diagnostics.Debug.WriteLine($"[SHELL DEBUG] {label}:");
            System.Diagnostics.Debug.WriteLine($"[SHELL DEBUG] Current Location: {loc}");
            System.Diagnostics.Debug.WriteLine($"[SHELL DEBUG] Navigation Stack Count: {stack.Count}");
            for (int i = 0; i < stack.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine($"[SHELL DEBUG]  [{i}] {stack[i]?.GetType().Name}");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[SHELL DEBUG] Error logging shell state: {ex.Message}");
        }
    }
}
