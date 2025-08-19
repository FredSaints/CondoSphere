using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace CondoSphere.Web.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        public ImageService(IWebHostEnvironment env, IConfiguration config)
        {
            _env = env;
            _config = config;
        }

        public async Task<string> SaveImageAsync(IFormFile imageFile, string folder, string? currentImagePath = null)
        {
            // 1) Delete previous file if it lived under /uploads/
            try
            {
                if (!string.IsNullOrWhiteSpace(currentImagePath))
                {
                    const string uploadsMarker = "/uploads/";
                    var idx = currentImagePath.IndexOf(uploadsMarker, StringComparison.OrdinalIgnoreCase);
                    if (idx >= 0)
                    {
                        var subPath = currentImagePath.Substring(idx + uploadsMarker.Length)
                                                      .Replace('/', Path.DirectorySeparatorChar);

                        var rootSetting = _config["FileUpload:Path"];
                        if (!string.IsNullOrWhiteSpace(rootSetting))
                        {
                            var root = Environment.ExpandEnvironmentVariables(rootSetting);
                            if (!Path.IsPathRooted(root))
                                root = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), root));

                            var oldPath = Path.Combine(root, subPath);
                            if (File.Exists(oldPath)) File.Delete(oldPath);
                        }
                    }
                }
            }
            catch
            {
                // Intentionally swallow: deletion failure shouldn't block upload
            }

            // 2) Resolve FileUpload:Path generically (env var + relative -> absolute)
            var uploadsRootSetting = _config["FileUpload:Path"];
            if (string.IsNullOrWhiteSpace(uploadsRootSetting))
                throw new InvalidOperationException("Missing FileUpload:Path in configuration.");

            var uploadsRoot = Environment.ExpandEnvironmentVariables(uploadsRootSetting);
            if (!Path.IsPathRooted(uploadsRoot))
                uploadsRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), uploadsRoot));

            // 3) Ensure target folder
            var safeFolder = string.IsNullOrWhiteSpace(folder) ? "" : folder.Trim().Trim('/', '\\');
            if (safeFolder.Contains("..")) throw new InvalidOperationException("Invalid folder name.");
            var targetDir = Path.Combine(uploadsRoot, safeFolder);
            Directory.CreateDirectory(targetDir);

            // 4) Save file
            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(imageFile.FileName)}";
            var filePath = Path.Combine(targetDir, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            // 5) Return a relative URL that the Web app will serve
            return $"/uploads/{(string.IsNullOrEmpty(safeFolder) ? "" : safeFolder + "/")}{uniqueFileName}";
        }
    }
}