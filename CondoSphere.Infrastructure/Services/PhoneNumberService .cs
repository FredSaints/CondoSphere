using CondoSphere.Application.Interfaces;
using System.Linq;

namespace CondoSphere.Infrastructure.Services
{
    public class PhoneNumberService : IPhoneNumberService
    {
        public string Normalize(string? raw, string defaultCountryCode = "+351")
        {
            if (string.IsNullOrWhiteSpace(raw)) return "";

            var digits = new string(raw.Where(char.IsDigit).ToArray());

            if (raw.Trim().StartsWith("+"))
                return "+" + digits;

            if (digits.StartsWith("00"))
                return "+" + digits[2..];

            if (digits.Length == 9) // típico em PT
                return defaultCountryCode + digits;

            return defaultCountryCode + digits;
        }
    }
}
