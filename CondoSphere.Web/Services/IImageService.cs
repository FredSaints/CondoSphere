namespace CondoSphere.Web.Services
{
    /// <summary>
    /// I Image Service.
    /// </summary>
    public interface IImageService
    {
        Task<string> SaveImageAsync(IFormFile imageFile, string folder, string? currentImagePath = null);
    }
}