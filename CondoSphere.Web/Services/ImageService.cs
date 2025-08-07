namespace CondoSphere.Web.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _env;

        public ImageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SaveImageAsync(IFormFile imageFile, string folder, string? currentImagePath = null)
        {
            if (!string.IsNullOrEmpty(currentImagePath))
            {
                var oldFullPath = Path.Combine(_env.WebRootPath, currentImagePath.TrimStart('/'));
                if (File.Exists(oldFullPath))
                {
                    File.Delete(oldFullPath);
                }
            }

            var uploadsFolder = Path.Combine(_env.WebRootPath, "images", folder);
            if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(imageFile.FileName)}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return $"/images/{folder}/{uniqueFileName}";
        }
    }
}