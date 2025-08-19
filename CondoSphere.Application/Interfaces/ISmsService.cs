using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Application.Interfaces
{
    public interface ISmsService
    {
        Task<(bool Success, string? Error)> SendSmsAsync(string toE164, string message);
    }
}
