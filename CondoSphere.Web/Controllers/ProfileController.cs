using CondoSphere.Core.DTOs.Account;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CondoSphere.Web.Controllers
{
    [Authorize]
    [Route("profile")]    public class ProfileController : Controller
    {
        private readonly ApiClient _apiClient;
        private readonly IImageService _imageService;
        private readonly IConfiguration _configuration;
        private readonly IAccessTokenStore _accessTokenStore;

        public ProfileController(ApiClient apiClient, IImageService imageService, IConfiguration configuration, IAccessTokenStore accessTokenStore)
        {
            _apiClient = apiClient;
            _imageService = imageService;
            _configuration = configuration;
            _accessTokenStore = accessTokenStore;
        }

        [HttpGet("")]        public async Task<IActionResult> Index()
        {
            var email = User.FindFirstValue(ClaimTypes.Email) ?? User.Identity?.Name ?? "";

            var model = new MyProfileViewModel
            {
                FirstName = User.FindFirstValue(ClaimTypes.GivenName) ?? "",
                LastName = User.FindFirstValue(ClaimTypes.Surname) ?? "",
                PhoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone) ?? "",
                CurrentProfileImageUrl = User.FindFirstValue("profile_picture"),
                TwoFactorEnabled = await _apiClient.IsTwoFactorEnabledAsync(new EmailDto { Email = email })
            };

            return View(model);
        }

        [HttpPost("")]
        [ValidateAntiForgeryToken]        public async Task<IActionResult> Index(MyProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.CurrentProfileImageUrl = User.FindFirstValue("profile_picture");
                return View(model);
            }

            string? finalImageUrl = model.CurrentProfileImageUrl;
            if (model.ProfileImage != null && model.ProfileImage.Length > 0)
            {
                finalImageUrl = await _imageService.SaveImageAsync(
                    model.ProfileImage, "user-photos", model.CurrentProfileImageUrl);
            }

            var dto = new UpdateProfileDto
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                ProfilePictureUrl = finalImageUrl
            };

            var (success, message, newToken) = await _apiClient.UpdateProfileAsync(dto);

            string? errorToSurface = null;

            if (success && !string.IsNullOrEmpty(newToken))
            {
                var handler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                };

                try
                {
                    var principal = handler.ValidateToken(newToken, validationParameters, out var validatedToken);
                    var jwtToken = handler.ReadJwtToken(newToken);

                    HttpContext.Response.Headers["X-Profile-TokenType"] = validatedToken?.GetType().Name ?? "<null>";
                    var debugSummary = $"audCfg={validationParameters.ValidAudience ?? "<null>"};tokenAud={(jwtToken.Audiences.Any() ? string.Join(',', jwtToken.Audiences) : "<none>")};issCfg={validationParameters.ValidIssuer ?? "<null>"};tokenIss={jwtToken.Issuer ?? "<null>"};claimCount={principal.Claims.Count()}";
                    debugSummary = debugSummary.Replace('\r', ' ').Replace('\n', ' ');
                    if (debugSummary.Length > 256)
                    {
                        debugSummary = debugSummary.Substring(0, 256);
                    }
                    HttpContext.Response.Headers["X-Profile-Debug"] = debugSummary;

                    var claimsIdentity = (ClaimsIdentity)principal.Identity!;
                    EnsureNameClaims(claimsIdentity);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        new AuthenticationProperties { IsPersistent = true });

                    _accessTokenStore.SaveToken(HttpContext, newToken);
                    HttpContext.User = new ClaimsPrincipal(claimsIdentity);
                    TempData["SuccessMessage"] = "Your profile has been updated.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    var errorText = ($"{ex.GetType().Name}:{ex.Message}").Replace('\r', ' ').Replace('\n', ' ');
                    if (errorText.Length > 256)
                    {
                        errorText = errorText.Substring(0, 256);
                    }
                    HttpContext.Response.Headers["X-Profile-Error"] = errorText;
                    errorToSurface = "Failed to refresh authentication token. Please sign in again.";
                }
            }
            else if (success)
            {
                HttpContext.Response.Headers["X-Profile-Debug"] = "Profile update succeeded but API returned no token.";

                if (HttpContext.User.Identity is ClaimsIdentity existingIdentity && existingIdentity.IsAuthenticated)
                {
                    ReplaceClaimValue(existingIdentity, ClaimTypes.GivenName, model.FirstName);
                    ReplaceClaimValue(existingIdentity, ClaimTypes.Surname, model.LastName);
                    ReplaceClaimValue(existingIdentity, ClaimTypes.MobilePhone, model.PhoneNumber);
                    ReplaceClaimValue(existingIdentity, "profile_picture", finalImageUrl);

                    EnsureNameClaims(existingIdentity);

                    var refreshedPrincipal = new ClaimsPrincipal(existingIdentity);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        refreshedPrincipal,
                        new AuthenticationProperties { IsPersistent = true });

                    HttpContext.User = refreshedPrincipal;
                }

                TempData["SuccessMessage"] = string.IsNullOrWhiteSpace(message)
                    ? "Your profile has been updated."
                    : message;

                return RedirectToAction("Index");
            }
            else
            {
                errorToSurface = string.IsNullOrWhiteSpace(message)
                    ? "Failed to update your profile. Please try again."
                    : message;
            }

            if (string.IsNullOrWhiteSpace(errorToSurface))
            {
                errorToSurface = "Failed to update your profile. Please try again.";
            }

            ModelState.AddModelError(string.Empty, errorToSurface);
            model.CurrentProfileImageUrl = User.FindFirstValue("profile_picture");
            return View(model);
        }
        private static void EnsureNameClaims(ClaimsIdentity identity)
        {
            var firstName = identity.FindFirst(ClaimTypes.GivenName)?.Value
                           ?? identity.FindFirst("firstName")?.Value;
            var lastName = identity.FindFirst(ClaimTypes.Surname)?.Value
                          ?? identity.FindFirst("lastName")?.Value;

            if (!string.IsNullOrWhiteSpace(firstName) && identity.FindFirst(ClaimTypes.GivenName) == null)
            {
                identity.AddClaim(new Claim(ClaimTypes.GivenName, firstName));
            }

            if (!string.IsNullOrWhiteSpace(lastName) && identity.FindFirst(ClaimTypes.Surname) == null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Surname, lastName));
            }

            if (identity.FindFirst(ClaimTypes.Name) == null)
            {
                var parts = new[] { firstName, lastName }
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToArray();
                if (parts.Length > 0)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Name, string.Join(" ", parts)));
                }
            }
        }

        private static void ReplaceClaimValue(ClaimsIdentity identity, string claimType, string? value)
        {
            foreach (var existing in identity.FindAll(claimType).ToList())
            {
                identity.RemoveClaim(existing);
            }

            if (!string.IsNullOrWhiteSpace(value))
            {
                identity.AddClaim(new Claim(claimType, value));         }
        }
/// <summary>
/// Toggle2 Fa Vm.
/// </summary>
public class Toggle2FaVm { public bool Enable { get;set; } }

        [HttpPost("ToggleTwoFactor")]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Toggle Two Factor action.
/// </summary>
public async Task<IActionResult> ToggleTwoFactor([FromBody] Toggle2FaVm vm)
        {
            var email = User.FindFirstValue(ClaimTypes.Email) ?? User.Identity?.Name ?? "";
            var result = await _apiClient.SwitchTwoFactorAsync(new ToggleTwoFactorDto
            {    Email = email,
                Enable = vm.Enable
            });if (result.Success) return Ok(new { message = result.Message });          return BadRequest(new { message = result.Message });
        }

        [HttpGet("change-password")]
/// <summary>
/// Handles the Change Password action.
/// </summary>
public IActionResult ChangePassword() => View(new ChangePasswordViewModel());

        [HttpPost("change-password")]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Change Password action.
/// </summary>
public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

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

