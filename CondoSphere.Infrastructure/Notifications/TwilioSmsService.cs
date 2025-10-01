using CondoSphere.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CondoSphere.Infrastructure.Notifications
{
    /// <summary>
    /// Twilio Sms Service.
    /// </summary>
    public class TwilioSmsService : ISmsService
    {
        private readonly string _sid;
        private readonly string _token;
        private readonly string _from;

        public TwilioSmsService(IConfiguration cfg)
        {
            _sid = cfg["Twilio:AccountSid"] ?? "";
            _token = cfg["Twilio:AuthToken"] ?? "";
            _from = cfg["Twilio:FromNumber"] ?? "";
            TwilioClient.Init(_sid, _token);
        }

        public async Task<(bool Success, string? Error)> SendSmsAsync(string toE164, string message)
        {
            try
            {
                var msg = await MessageResource.CreateAsync(
                    to: toE164,
                    from: _from,                 
                    body: message);

                return (msg.ErrorCode == null, msg.ErrorMessage);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
