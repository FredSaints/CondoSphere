namespace CondoSphere.Web.Services
{
    public interface IImageService
    {
        Task<string> SaveImageAsync(IFormFile imageFile, string folder, string? currentImagePath = null);
    }
}