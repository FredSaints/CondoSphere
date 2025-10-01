namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// I Mail Service.
    /// </summary>
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }
}