using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.Enums;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CondoSphere.Web.Controllers
{    public class AccountController : Controller
    {
        private readonly ApiClient _apiClient;
        private readonly IConfiguration _configuration;
        private readonly IAccessTokenStore _accessTokenStore;

        private const string TwoFactorEmailSessionKey = "TwoFactor:Email";
        private const string TwoFactorMethodsSessionKey = "TwoFactor:Methods";
        private const string TwoFactorSelectedMethodSessionKey = "TwoFactor:SelectedMethod";
        private const string TwoFactorLoginPayloadSessionKey = "TwoFactor:PendingLogin";
        private const string TwoFactorReturnUrlSessionKey = "TwoFactor:ReturnUrl";

        public AccountController(ApiClient apiClient, IConfiguration configuration, IAccessTokenStore accessTokenStore)
        {
            _apiClient = apiClient;
            _configuration = configuration;
            _accessTokenStore = accessTokenStore;
        }

        [HttpGet]        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        public async Task<IActionResult> Login(LoginDto model, string? returnUrl = null)
        {
            ClearTwoFactorState();

            if (!ModelState.IsValid)
                return View(model);

            var (isConfirmed, _) = await _apiClient.IsEmailConfirmedAsync(model.Email);
            if (!isConfirmed)
                return RedirectToAction("ResendConfirmationEmail", new { email = model.Email });

            var userDto = await _apiClient.LoginAsync(model);
            if (userDto == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            if (userDto.RequiresTwoFactor)
            {
                if (userDto.TwoFactorMethods == null || userDto.TwoFactorMethods.Count == 0)
                {
                    ModelState.AddModelError(string.Empty, "Two-factor authentication is enabled, but no delivery method is configured. Please contact support.");
                    return View(model);
                }

                StoreTwoFactorState(userDto.Email, userDto.TwoFactorMethods, model, returnUrl);
                return RedirectToAction(nameof(ChooseTwoFactorMethod));
            }

            if (!string.IsNullOrWhiteSpace(userDto.Token))
            {
                await SignInWithJwtAsync(userDto.Token);
                return RedirectAfterLogin(returnUrl);
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        [HttpGet("ChooseTwoFactorMethod")]
        [AllowAnonymous]
/// <summary>
/// Handles the Choose Two Factor Method action.
/// </summary>
public IActionResult ChooseTwoFactorMethod(string? email = null)
        {
            var state = GetTwoFactorState();
            if (state == null)
            {
                ClearTwoFactorState();
                return RedirectToAction(nameof(Login));
            }

            var methods = state.Value.Methods;
            if (methods.Count == 0)
            {
                ClearTwoFactorState();
                return RedirectToAction(nameof(Login));
            }

            var selected = GetSelectedTwoFactorMethod();
            if (string.IsNullOrWhiteSpace(selected) || !methods.Any(m => string.Equals(m, selected, StringComparison.OrdinalIgnoreCase)))
            {
                selected = methods[0];
                SetSelectedTwoFactorMethod(selected);
            }

            ViewBag.AllowEmailMethod = methods.Any(m => string.Equals(m, "Email", StringComparison.OrdinalIgnoreCase));
            ViewBag.AllowSmsMethod = methods.Any(m => string.Equals(m, "Sms", StringComparison.OrdinalIgnoreCase));

            return View(new TwoFactorChooseMethodViewModel
            {
                Email = state.Value.Email,
                SelectedMethod = selected
            });
        }

        [HttpPost("ChooseTwoFactorMethod")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Choose Two Factor Method action.
/// </summary>
public async Task<IActionResult> ChooseTwoFactorMethod(TwoFactorChooseMethodViewModel vm)
        {
            var state = GetTwoFactorState();
            if (state == null)
            {
                ClearTwoFactorState();
                return RedirectToAction(nameof(Login));
            }

            var methods = state.Value.Methods;
            if (methods.Count == 0)
            {
                ClearTwoFactorState();
                return RedirectToAction(nameof(Login));
            }

            var normalized = NormalizeTwoFactorMethod(vm.SelectedMethod, methods);
            if (normalized == null)
            {
                ModelState.AddModelError(string.Empty, "Selected delivery method is not available.");
                vm.Email = state.Value.Email;
                ViewBag.AllowEmailMethod = methods.Any(m => string.Equals(m, "Email", StringComparison.OrdinalIgnoreCase));
                ViewBag.AllowSmsMethod = methods.Any(m => string.Equals(m, "Sms", StringComparison.OrdinalIgnoreCase));
                return View(vm);
            }

            var methodEnum = string.Equals(normalized, "Sms", StringComparison.OrdinalIgnoreCase)
                ? TwoFactorMethod.Sms
                : TwoFactorMethod.Email;

            var send = await _apiClient.SendTwoFactorCodeAsync(new SendTwoFactorCodeDto
            {
                Email = state.Value.Email,
                Method = methodEnum
            });

            if (!send.Success)
            {
                ModelState.AddModelError(string.Empty, send.Message);
                vm.Email = state.Value.Email;
                vm.SelectedMethod = normalized;
                ViewBag.AllowEmailMethod = methods.Any(m => string.Equals(m, "Email", StringComparison.OrdinalIgnoreCase));
                ViewBag.AllowSmsMethod = methods.Any(m => string.Equals(m, "Sms", StringComparison.OrdinalIgnoreCase));
                return View(vm);
            }

            SetSelectedTwoFactorMethod(normalized);
            return RedirectToAction(nameof(VerifyTwoFactor));
        }

        [HttpGet("VerifyTwoFactor")]
        [AllowAnonymous]
/// <summary>
/// Handles the Verify Two Factor action.
/// </summary>
public IActionResult VerifyTwoFactor(string? method = null)
        {
            var state = GetTwoFactorState();
            if (state == null)
            {
                ClearTwoFactorState();
                return RedirectToAction(nameof(Login));
            }

            var methods = state.Value.Methods;
            if (methods.Count == 0)
            {
                ClearTwoFactorState();
                return RedirectToAction(nameof(Login));
            }

            var selected = !string.IsNullOrWhiteSpace(method)
                ? NormalizeTwoFactorMethod(method, methods)  : GetSelectedTwoFactorMethod();

            if (selected == null)
            {
                        selected = methods[0];
            }

            SetSelectedTwoFactorMethod(selected);

            return View(new TwoFactorVerifyViewModel
            {
                Email = state.Value.Email,
                SelectedMethod = selected
            });
        }

        [HttpPost("VerifyTwoFactor")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Verify Two Factor action.
/// </summary>
public async Task<IActionResult> VerifyTwoFactor(TwoFactorVerifyViewModel vm)
        {
            var state = GetTwoFactorState();
            if (state == null)
            {
                ClearTwoFactorState();
                return RedirectToAction(nameof(Login));
            }

            if (!ModelState.IsValid)
            {
                vm.Email = state.Value.Email;
                vm.SelectedMethod = GetSelectedTwoFactorMethod() ?? vm.SelectedMethod;
                return View(vm);
            }

            var methods = state.Value.Methods;
            var selected = NormalizeTwoFactorMethod(vm.SelectedMethod, methods) ?? GetSelectedTwoFactorMethod() ?? methods.FirstOrDefault();

            if (selected == null)
            {
                ModelState.AddModelError(string.Empty, "Selected delivery method is no longer available.");
                vm.Email = state.Value.Email;
                return View(vm);
            }

            var methodEnum = string.Equals(selected, "Sms", StringComparison.OrdinalIgnoreCase)
                ? TwoFactorMethod.Sms
                : TwoFactorMethod.Email;

            var verify = await _apiClient.VerifyTwoFactorCodeAsync(new VerifyTwoFactorCodeDto
            {
                Email = state.Value.Email,
                Method = methodEnum,
                Code = vm.Code
            });

            if (!verify.Success)
            {
                ModelState.AddModelError(string.Empty, verify.Message);
                vm.Email = state.Value.Email;
                vm.SelectedMethod = selected;
                return View(vm);
            }

            var token = verify.Token;
            if (string.IsNullOrWhiteSpace(token))
            {
                var fallback = await _apiClient.LoginAsync(state.Value.Login);
                token = fallback?.Token;
                if (string.IsNullOrWhiteSpace(token))
                {
                    ModelState.AddModelError(string.Empty, "Could not complete sign-in after verification.");
                    vm.Email = state.Value.Email;
                    vm.SelectedMethod = selected;
                    return View(vm);
                }
            }

            await SignInWithJwtAsync(token);

            var returnUrl = state.Value.ReturnUrl;
            ClearTwoFactorState();
            return RedirectAfterLogin(returnUrl);
        }

        private async Task SignInWithJwtAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT signing key configuration is missing.");

            ClaimsPrincipal principal;
            try
            {
                principal = handler.ValidateToken(
                    token,
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    },
                    out var validatedToken);

                HttpContext.Response.Headers["X-Auth-TokenType"] = validatedToken?.GetType().Name ?? "<null>";
            }
            catch (Exception ex)
            {
                var errorText = ($"{ex.GetType().Name}:{ex.Message}").Replace('\r', ' ').Replace('\n', ' ');
                HttpContext.Response.Headers["X-Auth-Error"] = errorText.Length > 256 ? errorText.Substring(0, 256) : errorText;
                throw;
            }

            var claimsIdentity = (ClaimsIdentity)principal.Identity!;
            EnsureNameClaims(claimsIdentity, principal.Claims);

            var roles = claimsIdentity.FindAll(ClaimTypes.Role).Select(r => r.Value).ToArray();
            var debugSummary = $"user={claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "<null>"};roles={(roles.Length > 0 ? string.Join(',', roles) : "<none>")};aud={audience ?? "<null>"};iss={issuer ?? "<null>"};claimCount={claimsIdentity.Claims.Count()}";
            debugSummary = debugSummary.Replace('\r', ' ').Replace('\n', ' ');
            if (debugSummary.Length > 256)
            {
                debugSummary = debugSummary.Substring(0, 256);
            }
            HttpContext.Response.Headers["X-Auth-Debug"] = debugSummary;

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
            };

            var refreshedPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                refreshedPrincipal,
                authProperties
            );

            _accessTokenStore.SaveToken(HttpContext, token);
            HttpContext.User = refreshedPrincipal;
        }

        private void StoreTwoFactorState(string email, IReadOnlyCollection<string> methods, LoginDto loginDto, string? returnUrl)
        {
            if (HttpContext?.Session == null) return;

            var normalizedMethods = methods
                .Where(m => !string.IsNullOrWhiteSpace(m))
                .Select(m => m.Trim())
                .Distinct(System.StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (normalizedMethods.Count == 0)
            {
                ClearTwoFactorState();
                return;
            }

            HttpContext.Session.SetString(TwoFactorEmailSessionKey, email ?? string.Empty);
            HttpContext.Session.SetString(TwoFactorMethodsSessionKey, JsonSerializer.Serialize(normalizedMethods));
            HttpContext.Session.SetString(TwoFactorLoginPayloadSessionKey, JsonSerializer.Serialize(loginDto));
            HttpContext.Session.SetString(TwoFactorReturnUrlSessionKey, returnUrl ?? string.Empty);
            HttpContext.Session.Remove(TwoFactorSelectedMethodSessionKey);
        }

        private (string Email, List<string> Methods, LoginDto Login, string? ReturnUrl)? GetTwoFactorState()
        {
            if (HttpContext?.Session == null) return null;

            var email = HttpContext.Session.GetString(TwoFactorEmailSessionKey);
            var methodsJson = HttpContext.Session.GetString(TwoFactorMethodsSessionKey);
            var loginJson = HttpContext.Session.GetString(TwoFactorLoginPayloadSessionKey);

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(methodsJson) || string.IsNullOrWhiteSpace(loginJson))
            {
                return null;
            }

            List<string>? methods;
            try
            {
                methods = JsonSerializer.Deserialize<List<string>>(methodsJson);
            }
            catch
            {
                methods = null;
            }

            LoginDto? login;
            try
            {
                login = JsonSerializer.Deserialize<LoginDto>(loginJson);
            }
            catch
            {
                login = null;
            }

            if (methods == null || methods.Count == 0 || login == null)
            {
                return null;
            }

            var returnUrl = HttpContext.Session.GetString(TwoFactorReturnUrlSessionKey);
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = null;
            }

            return (email!, methods, login, returnUrl);
        }

        private string? NormalizeTwoFactorMethod(string? method, IReadOnlyCollection<string> available)
        {
            if (string.IsNullOrWhiteSpace(method))
            {
                return null;
            }

            foreach (var option in available)
            {
                if (string.Equals(option, method, StringComparison.OrdinalIgnoreCase))
                {
                    return option;
                }
            }

            return null;
        }

        private void SetSelectedTwoFactorMethod(string method)
        {
            if (HttpContext?.Session == null) return;

            HttpContext.Session.SetString(TwoFactorSelectedMethodSessionKey, method ?? string.Empty);
        }

        private string? GetSelectedTwoFactorMethod()
        {
            if (HttpContext?.Session == null) return null;

            var value = HttpContext.Session.GetString(TwoFactorSelectedMethodSessionKey);
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }

        private void ClearTwoFactorState()
        {
            if (HttpContext?.Session == null) return;

            HttpContext.Session.Remove(TwoFactorEmailSessionKey);
            HttpContext.Session.Remove(TwoFactorMethodsSessionKey);HttpContext.Session.Remove(TwoFactorSelectedMethodSessionKey);
            HttpContext.Session.Remove(TwoFactorLoginPayloadSessionKey);
            HttpContext.Session.Remove(TwoFactorReturnUrlSessionKey);
        }

        private IActionResult Red        /// <summary>
        /// Handles the Access Denied action.
        /// </summary>
irectAfterLogin(string? returnUrl)
        {
            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectByRoleOrHome();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Logout action.
/// </summary>
public async Task<IActionResult> Logout()
        {
            _accessTokenStore.ClearToken(HttpContext);    HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
/// <summary>
/// Handles the Access Denied action.
/// </summary>
public IActionResult AccessDenied()        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
/// <summary>
/// Handles the Set Password action.
/// </summary>
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
/// <summary>
/// Handles the Set Password action.
/// </summary>
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
            return View(model); }

        [HttpGet]
        [AllowAnonymous]
/// <summary>
/// Handles the Register action.
/// </summary>
public IActionResult Register()
        {
            return View(new RegisterDto());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Register action.
/// </summary>
public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var (success, message) = await _apiClient.RegisterCompanyAdminAsync(model);      if (success)
            {
                TempData["SuccessMessage"] = message;
                return RedirectToAction("RegistrationComplete");
            }
            ModelState.AddModelError(string.Empty, message);
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
/// <summary>
/// Handles the Registration Complete action.
/// </summary>
public IActionResult RegistrationComplete()
        {
                  return View();
        }

        [HttpGet]
        [AllowAnonymous]
        pu        /// <summary>
        /// Handles the Forgot Password Confirmation action.
        /// </summary>
blic async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
            {
                return RedirectToAction("Index", "Home");        /// <summary>
        /// Handles the Resend Confirmation Email action.
        /// </summary>

            }            var (success, message) = await _apiClient.ConfirmEmailAsync(userId, token);
            if (success)
            {
                TempData["SuccessMessage"] = message;
                return RedirectToAction("Login");
            }
            else
            {
                TempData["ErrorMessage"] = message;
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        [AllowAnonymous]
/// <summary>
/// Handles the Forgot Password action.
/// </summary>
public IActionResult ForgotPassword()
        {
            return View(new ForgotPasswordViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Forgot Password action.
/// </summary>
public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var (success, rawMessage) = await _apiClient.ForgotPasswordAsync(model.Email);
            string displayMessage = JsonDocument.Parse(rawMessage).RootElement.GetProperty("message").GetString();
            return RedirectToAction("ForgotPasswordConfirmation", new { message = displayMessage });
        }

        [HttpGet]
        [AllowAnonymous]
/// <summary>
/// Handles the Forgot Password Confirmation action.
/// </summary>
public IActionResult ForgotPasswordConfirmation(string message)
        {
            ViewData["Message"] = message;
            return View();
        }

        [AllowAnonymous]
/// <summary>
/// Handles the Resend Confirmation Email action.
/// </summary>
public IActionResult ResendConfirmationEmail(string? email = null)
        {
            return View(new ResendConfirmationEmailViewModel { Email = email ?? "" });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
/// <summary>
/// Handles the Resend Confirmation Email action.
/// </summary>
public async Task<IActionResult> ResendConfirmationEmail(ResendConfirmationEmailViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var (success, _) = await _apiClient.ResendConfirmationEmailAsync(model.Email);
            ViewData["Mensagem"] = success
               ? "If an account with that email exists, the confirmation link has been resent."
: "An error occurred while trying to resend the confirmation email.";
            return View(model);
        }

        private static void EnsureNameClaims(ClaimsIdentity identity, IEnumerable<Claim> tokenClaims)
        {
            var firstNameClaim = identity.FindFirst(ClaimTypes.GivenName)?.Value;
            if (string.IsNullOrWhiteSpace(firstNameClaim))
            {
                firstNameClaim = tokenClaims.FirstOrDefault(c => c.Type == "firstName")?.Value;
                if (!string.IsNullOrWhiteSpace(firstNameClaim))
                {
                    identity.AddClaim(new Claim(ClaimTypes.GivenName, firstNameClaim));
                }
            }

            var lastNameClaim = identity.FindFirst(ClaimTypes.Surname)?.Value;
            if (string.IsNullOrWhiteSpace(lastNameClaim))
            {
                lastNameClaim = tokenClaims.FirstOrDefault(c => c.Type == "lastName")?.Value;
                if (!string.IsNullOrWhiteSpace(lastNameClaim))
                {
                    identity.AddClaim(new Claim(ClaimTypes.Surname, lastNameClaim));
                }
            }

            if (identity.FindFirst(ClaimTypes.Name) == null)
            {
                var fullName = new[] { firstNameClaim, lastNameClaim }
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToArray();
                if (fullName.Length > 0)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Name, string.Join(" ", fullName)));
                }
            }
        }

        private IActionResult RedirectByRoleOrHome()
        {
            if (User.IsInRole(RoleConstants.CompanyAdmin))
                return RedirectToAction("Index", "Administration");
            if (User.IsInRole(RoleConstants.CondoManager))
                return RedirectToAction("Index", "CondoManagement");
            if (User.IsInRole(RoleConstants.CondoResident))
                return RedirectToAction("Index", "Portal");
            if (User.IsInRole(RoleConstants.Employee))
                return RedirectToAction("Index", "Employee");
            return RedirectToAction("Index", "Home");
        }
    }
}



