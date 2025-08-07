//using CondoSphere.Core.DTOs.Account;
//using CondoSphere.Core.Entities.Users;
//using CondoSphere.Web.Models;
//using CondoSphere.Web.Services;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;

//namespace CondoSphere.Web.Controllers
//{
//    [Authorize]
//    [Route("profile")]
//    public class ProfileController : Controller
//    {
//        private readonly ApiClient _apiClient;
//        private readonly IImageService _imageService;
//        private readonly UserManager<User> _userManager;
//        private readonly SignInManager<User> _signInManager;

//        public ProfileController(ApiClient apiClient, IImageService imageService, UserManager<User> userManager, SignInManager<User> signInManager)
//        {
//            _apiClient = apiClient;
//            _imageService = imageService;
//            _userManager = userManager;
//            _signInManager = signInManager;
//        }

//        [HttpGet("")]
//        public IActionResult Index()
//        {
//            var model = new MyProfileViewModel
//            {
//                FirstName = User.FindFirstValue(ClaimTypes.GivenName) ?? "",
//                LastName = User.FindFirstValue(ClaimTypes.Surname) ?? "",
//                CurrentProfileImageUrl = User.FindFirstValue("profile_picture")
//            };
//            return View(model);
//        }

//        //[HttpPost("")]
//        //[ValidateAntiForgeryToken]
//        //public async Task<IActionResult> Index(MyProfileViewModel model)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return View(model);
//        //    }

//        //    // This part remains the same: save the image and update the database via the API.
//        //    string? newImageUrl = model.CurrentProfileImageUrl;
//        //    if (model.ProfileImage != null && model.ProfileImage.Length > 0)
//        //    {
//        //        newImageUrl = await _imageService.SaveImageAsync(model.ProfileImage, "user-photos", model.CurrentProfileImageUrl);
//        //    }
//        //    var dto = new UpdateProfileDto
//        //    {
//        //        FirstName = model.FirstName,
//        //        LastName = model.LastName,
//        //        ProfilePictureUrl = newImageUrl
//        //    };
//        //    var (success, message) = await _apiClient.UpdateProfileAsync(dto);

//        //    if (success)
//        //    {
//        //        // ===== THIS IS THE NEW SESSION REFRESH LOGIC =====

//        //        // 1. Fetch the user's complete, updated profile from the API.
//        //        var updatedProfile = await _apiClient.GetMyProfileAsync();
//        //        if (updatedProfile != null)
//        //        {
//        //            // 2. Create a new set of claims based on the fresh data.
//        //            var claims = new List<Claim>
//        //    {
//        //        new Claim(ClaimTypes.NameIdentifier, updatedProfile.Id.ToString()),
//        //        new Claim(ClaimTypes.Name, updatedProfile.Email),
//        //        new Claim(ClaimTypes.Email, updatedProfile.Email),
//        //        new Claim(ClaimTypes.GivenName, updatedProfile.FirstName),
//        //        new Claim(ClaimTypes.Surname, updatedProfile.LastName),
//        //        new Claim("profile_picture", updatedProfile.ProfilePictureUrl ?? "")
//        //    };
//        //            foreach (var role in updatedProfile.Roles)
//        //            {
//        //                claims.Add(new Claim(ClaimTypes.Role, role));
//        //            }
//        //            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//        //            var authProperties = new AuthenticationProperties { IsPersistent = true };

//        //            // 3. Sign the user in again. This replaces their old cookie with the new one.
//        //            await HttpContext.SignInAsync(
//        //                CookieAuthenticationDefaults.AuthenticationScheme,
//        //                new ClaimsPrincipal(claimsIdentity),
//        //                authProperties);
//        //        }

//        //        TempData["SuccessMessage"] = "Your profile has been updated.";
//        //        return RedirectToAction("Index");
//        //    }

//        //    ModelState.AddModelError(string.Empty, message);
//        //    return View(model);
//        //}

//        [HttpPost("")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Index(MyProfileViewModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(model);
//            }

//            string? newImageUrl = model.CurrentProfileImageUrl;
//            if (model.ProfileImage != null && model.ProfileImage.Length > 0)
//            {
//                newImageUrl = await _imageService.SaveImageAsync(model.ProfileImage, "user-photos", model.CurrentProfileImageUrl);
//            }

//            var dto = new UpdateProfileDto
//            {
//                FirstName = model.FirstName,
//                LastName = model.LastName,
//                ProfilePictureUrl = newImageUrl
//            };

//            var (success, message) = await _apiClient.UpdateProfileAsync(dto);

//            if (success)
//            {
//                var updatedProfile = await _apiClient.GetMyProfileAsync();
//                if (updatedProfile != null)
//                {
//                    // Use the user ID from the updated profile, not from claims
//                    var userId = updatedProfile.Id.ToString();

//                    var identityUser = await _userManager.FindByIdAsync(userId);

//                    // LOG: Show old and new info for diagnostics
//                    Console.WriteLine("BEFORE SIGN-IN:");
//                    Console.WriteLine("Current User ID: " + User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
//                    Console.WriteLine("Current User Name: " + User.Identity.Name);

//                    await _signInManager.SignOutAsync();
//                    await _signInManager.SignInAsync(identityUser, isPersistent: false);

//                    Console.WriteLine("AFTER SIGN-IN (same request):");
//                    Console.WriteLine("Current User ID: " + User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
//                    Console.WriteLine("Current User Name: " + User.Identity.Name);
//                    Console.WriteLine("Expected New Name: " + identityUser.FirstName + " " + identityUser.LastName);
//                }
//                TempData["SuccessMessage"] = "Your profile has been updated.";
//                return RedirectToAction("Index");
//            }

//            ModelState.AddModelError(string.Empty, message);
//            return View(model);
//        }

//        [HttpGet("change-password")]
//        public IActionResult ChangePassword()
//        {
//            return View(new ChangePasswordViewModel());
//        }

//        [HttpPost("change-password")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(model);
//            }

//            var (success, message) = await _apiClient.ChangePasswordAsync(model);
//            if (success)
//            {
//                ModelState.Clear();
//                TempData["SuccessMessage"] = "Your password has been changed successfully.";
//                return RedirectToAction("Index");
//            }

//            ModelState.AddModelError(string.Empty, "Failed to change password. Please check your current password and try again.");
//            return View(model);
//        }
//    }
//}

using CondoSphere.Core.DTOs.Account;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Web.Controllers
{
    [Authorize]
    [Route("profile")]
    public class ProfileController : Controller
    {
        private readonly ApiClient _apiClient;
        private readonly IImageService _imageService;
        private readonly IConfiguration _configuration; // Added for token validation

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
