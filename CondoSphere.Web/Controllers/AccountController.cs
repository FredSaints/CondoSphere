using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
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
    public class AccountController : Controller
    {
        private readonly ApiClient _apiClient;
        private readonly IConfiguration _configuration;

        public AccountController(ApiClient apiClient, IConfiguration configuration)
        {
            _apiClient = apiClient;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userDto = await _apiClient.LoginAsync(model);

            if (userDto == null || string.IsNullOrWhiteSpace(userDto.Token))
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            var handler = new JwtSecurityTokenHandler();
            var principal = handler.ValidateToken(
                userDto.Token,
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

            // Create a new claims identity to add our custom access_token claim
            var claimsIdentity = (ClaimsIdentity)principal.Identity;
            claimsIdentity.AddClaim(new Claim("access_token", userDto.Token));

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, // Make the cookie persistent
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
            };

            // Use the new identity with the added claim to sign in
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            if (User.IsInRole(RoleConstants.CompanyAdmin))
            {
                return RedirectToAction("Index", "Administration");
            }
            if (User.IsInRole(RoleConstants.CondoManager))
            {
                return RedirectToAction("Index", "CondoManagement");
            }
            if (User.IsInRole(RoleConstants.CondoResident))
            {
                return RedirectToAction("Index", "Portal");
            }

            return RedirectToAction("Index", "Home"); // Fallback for any other case
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Use the built-in method to sign out, which automatically clears the authentication cookie.
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        // Optional: An Access Denied page for users who are logged in but not authorized for a specific page.
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SetPassword(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return BadRequest("A user ID and token must be supplied for password set.");
            }

            var model = new SetPasswordDto { UserId = userId, Token = token };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetPassword(SetPasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _apiClient.SetPasswordAsync(model);

            if (success)
            {
                TempData["SuccessMessage"] = message;
                return RedirectToAction(nameof(Login));
            }

            ModelState.AddModelError(string.Empty, message);
            return View(model);
        }
    }
}