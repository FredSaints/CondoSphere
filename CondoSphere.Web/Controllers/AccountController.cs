using CondoSphere.Core.DTOs.Account;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
            // 0. Form validation ───────────────────────────────────────────
            if (!ModelState.IsValid)
                return View(model);

            // 1. Ask the API to authenticate and return a JWT ──────────────
            var userDto = await _apiClient.LoginAsync(model);

            if (userDto == null || string.IsNullOrWhiteSpace(userDto.Token))
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            // 2. Validate the JWT **and** map the "name" claim correctly ───
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

            // 3. Create the auth cookie ────────────────────────────────────
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                authProperties);

            // 4. Redirect ─────────────────────────────────────────────────
            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
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
    }
}