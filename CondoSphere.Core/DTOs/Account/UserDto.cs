using System;
using System.Collections.Generic;

namespace CondoSphere.Core.DTOs.Account
{
    /// <summary>
    /// Represents the data returned to the client after a successful login.
    /// </summary>
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public bool RequiresTwoFactor { get; set; }
        public IReadOnlyList<string> TwoFactorMethods { get; set; } = Array.Empty<string>();
    }
}
