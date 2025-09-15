using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Ensures only logged-in users can upload
    public class UploadController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public UploadController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpPost("profile-picture")]
        public async Task<IActionResult> UploadProfilePicture(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "No file uploaded." });
            }

            if(file.Length > 5 * 1024 * 1024) return BadRequest("File size exceeds 5MB.");

            var uploadRootSetting = _configuration["FileUpload:Path"];
            var uploadRoot = Environment.ExpandEnvironmentVariables(uploadRootSetting ?? "CondoSphere_Uploads");
            if (!Path.IsPathRooted(uploadRoot))
            {
                uploadRoot = Path.GetFullPath(Path.Combine(_env.ContentRootPath, uploadRoot));
            }

            var subfolder = "user-photos";
            var targetFolder = Path.Combine(uploadRoot, subfolder);
            Directory.CreateDirectory(targetFolder);

            var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var absoluteFilePath = Path.Combine(targetFolder, uniqueFileName);

            await using (var stream = new FileStream(absoluteFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var request = HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";

            var fileUrl = $"{baseUrl}/uploads/{subfolder}/{uniqueFileName}";

            return Ok(new { url = fileUrl });
        }
    }
}