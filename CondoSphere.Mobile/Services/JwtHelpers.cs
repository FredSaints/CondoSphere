using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace CondoSphere.Mobile.Services
{
    public static class JwtHelpers
    {
        /// <summary>
        /// Extract role names from a JWT. Supports:
        ///  - multiple "role" claims
        ///  - single "roles" claim (string or JSON array)
        ///  - "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
        /// </summary>
        public static IEnumerable<string> ExtractRoles(string? token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return Enumerable.Empty<string>();

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);

                // 1) Standard “role” claims
                var roles = jwt.Claims
                    .Where(c =>
                        c.Type == ClaimTypes.Role ||
                        c.Type.Equals("role", StringComparison.OrdinalIgnoreCase) ||
                        c.Type.Equals("roles", StringComparison.OrdinalIgnoreCase))
                    .SelectMany(c => SplitRolesClaimValue(c.Value))
                    .Where(r => !string.IsNullOrWhiteSpace(r))
                    .Select(r => r.Trim())
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();

                return roles;
            }
            catch
            {
                return Enumerable.Empty<string>();
            }
        }

        // Handles roles in formats: "Admin", "Admin,User", or '["Admin","User"]'
        private static IEnumerable<string> SplitRolesClaimValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Enumerable.Empty<string>();

            // JSON array?
            if (value.StartsWith("["))
            {
                try
                {
                    var arr = JsonSerializer.Deserialize<string[]>(value);
                    return arr ?? Array.Empty<string>();
                }
                catch { /* fall through */ }
            }

            // Comma-separated?
            if (value.Contains(','))
                return value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            // Single role
            return new[] { value };
        }
    }
}
