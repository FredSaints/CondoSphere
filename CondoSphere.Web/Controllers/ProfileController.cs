using CondoSphere.Core.DTOs.Account;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CondoSphere.Web.Controllers
{
    [Authorize]
    [Route("profile")]
    public class ProfileController : Controller
    {
        private readonly ApiClient _apiClient;
        private readonly IImageService _imageService;
        private readonly IConfiguration _configuration;

        public ProfileController(ApiClient apiClient, IImageService imageService, IConfiguration configuration)
        {
            _apiClient = apiClient;
            _imageService = imageService;
            _configuration = configuration;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new MyProfileViewModel
            {
                FirstName = User.FindFirstValue(ClaimTypes.GivenName) ?? "",
                LastName = User.FindFirstValue(ClaimTypes.Surname) ?? "",
                CurrentProfileImageUrl = User.FindFirstValue("profile_picture")
            };
            return View(model);
        }

        [HttpPost("")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(MyProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.CurrentProfileImageUrl = User.FindFirstValue("profile_picture");
                return View(model);
            }

            // Step 1: Handle file upload and determine the final image URL.
            string? finalImageUrl = model.CurrentProfileImageUrl;
            if (model.ProfileImage != null && model.ProfileImage.Length > 0)
            {
                finalImageUrl = await _imageService.SaveImageAsync(model.ProfileImage, "user-photos", model.CurrentProfileImageUrl);
            }

            // Step 2: Prepare the DTO to send to the API.
            var dto = new UpdateProfileDto
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfilePictureUrl = finalImageUrl
            };

            // Step 3: Call the API. It will return a new JWT on success.
            var (success, message, newToken) = await _apiClient.UpdateProfileAsync(dto);

            if (success && !string.IsNullOrEmpty(newToken))
            {
                // Step 4: Validate the new token and re-issue the authentication cookie.
                var handler = new JwtSecurityTokenHandler();
                var principal = handler.ValidateToken(
                    newToken,
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = _configuration["Jwt:Issuer"],
                        ValidAudience = _configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                    },
                    out _);

                var claimsIdentity = (ClaimsIdentity)principal.Identity;
                claimsIdentity.AddClaim(new Claim("access_token", newToken)); // Store the new token

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties { IsPersistent = true });

                TempData["SuccessMessage"] = "Your profile has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, message);
            model.CurrentProfileImageUrl = User.FindFirstValue("profile_picture");
            return View(model);
        }

        [HttpGet("change-password")]
        public IActionResult ChangePassword()
        {
            return View(new ChangePasswordViewModel());
        }

        [HttpPost("change-password")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _apiClient.ChangePasswordAsync(model);
            if (success)
            {
                ModelState.Clear();
                TempData["SuccessMessage"] = "Your password has been changed successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Failed to change password. Please check your current password and try again.");
            return View(model);
        }
    }
}
