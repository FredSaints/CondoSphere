using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Application.Interfaces
{
    public interface IPhoneNumberService
    {
        string Normalize(string? raw, string defaultCountryCode = "+351");
    }
}
