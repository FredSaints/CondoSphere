public static class TokenStorage
{
    private const string TokenKey = "auth_token";

    public static Task SaveTokenAsync(string token) =>
        SecureStorage.SetAsync(TokenKey, token);

    public static async Task<string?> GetTokenAsync()
    {
        try { return await SecureStorage.GetAsync(TokenKey); }
        catch { return null; }
    }

    public static async Task RemoveTokenAsync()
    {
        try
        {
            // SecureStorage has Remove, but wrap in Task to keep call sites async/await
            SecureStorage.Remove(TokenKey);
            await Task.CompletedTask;
        }
        catch { /* ignore */ }
    }
}
