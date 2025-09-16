using CondoSphere.Core;
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
using System.Text.Json;

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
                return View(model);

    
            var (isConfirmed, _) = await _apiClient.IsEmailConfirmedAsync(model.Email);
            if (!isConfirmed)
                return RedirectToAction("ResendConfirmationEmail", "Account", new { email = model.Email });


            var twoFactorOn = await _apiClient.IsTwoFactorEnabledAsync(new EmailDto { Email = model.Email });

            if (twoFactorOn)
            {

                TempData["PendingLogin"] = System.Text.Json.JsonSerializer.Serialize(model);
                TempData["ReturnUrl"] = returnUrl;
                TempData.Keep("PendingLogin");
                TempData.Keep("ReturnUrl");

                return RedirectToAction(nameof(ChooseTwoFactorMethod), new { email = model.Email });
            }
            else
            {
                // 2SV desativado → login direto (mantém como tinhas)
                var userDto = await _apiClient.LoginAsync(model);
                if (userDto != null && !string.IsNullOrWhiteSpace(userDto.Token))
                {
                    await SignInWithJwtAsync(userDto);
                    return RedirectByRoleOrHome();
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ChooseTwoFactorMethod(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return RedirectToAction(nameof(Login));

            TempData.Keep("PendingLogin");
            TempData.Keep("ReturnUrl");

            return View(new TwoFactorChooseMethodViewModel
            {
                Email = email,
                SelectedMethod = "Email" // default
            });
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChooseTwoFactorMethod(TwoFactorChooseMethodViewModel vm)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(vm.Email))
                return View(vm);

            TempData.Keep("PendingLogin");
            TempData.Keep("ReturnUrl");

            var methodEnum = vm.SelectedMethod?.ToLowerInvariant() == "sms"
                ? CondoSphere.Core.Enums.TwoFactorMethod.Sms
                : CondoSphere.Core.Enums.TwoFactorMethod.Email;

            // AGORA sim: envia o código conforme a escolha
            var send = await _apiClient.SendTwoFactorCodeAsync(new SendTwoFactorCodeDto
            {
                Email = vm.Email,
                Method = methodEnum
            });

            if (!send.Success)
            {
                ModelState.AddModelError(string.Empty, send.Message);
                return View(vm);
            }

            // segue para o ecrã de verificação com o método escolhido
            return RedirectToAction(nameof(VerifyTwoFactor), new { email = vm.Email, method = vm.SelectedMethod });
        }

        [HttpGet("VerifyTwoFactor")]
        [AllowAnonymous]
        public IActionResult VerifyTwoFactor(string email, string? method = "Email")
        {
            if (string.IsNullOrWhiteSpace(email))
                return RedirectToAction(nameof(Login));

            TempData.Keep("PendingLogin");
            TempData.Keep("ReturnUrl");

            return View(new TwoFactorVerifyViewModel
            {
                Email = email,
                SelectedMethod = string.IsNullOrWhiteSpace(method) ? "Email" : method
            });
        }

        [HttpPost("VerifyTwoFactor")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyTwoFactor(TwoFactorVerifyViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                TempData.Keep("PendingLogin");
                TempData.Keep("ReturnUrl");
                return View(vm);
            }

            var methodEnum = vm.SelectedMethod?.ToLowerInvariant() == "sms"
               ? CondoSphere.Core.Enums.TwoFactorMethod.Sms
               : CondoSphere.Core.Enums.TwoFactorMethod.Email;

            var verify = await _apiClient.VerifyTwoFactorCodeAsync(new VerifyTwoFactorCodeDto
            {
                Email = vm.Email,
                Method = methodEnum,
                Code = vm.Code
            });

            if (!verify.Success)
            {
                ModelState.AddModelError(string.Empty, verify.Message);
                TempData.Keep("PendingLogin");
                TempData.Keep("ReturnUrl");
                return View(vm);
            }

            // Código OK → refazer o login para obter o JWT (o endpoint /verify não devolve UserDto)
            if (!(TempData["PendingLogin"] is string serialized) || string.IsNullOrWhiteSpace(serialized))
                return RedirectToAction(nameof(Login));

            var loginDto = System.Text.Json.JsonSerializer.Deserialize<LoginDto>(serialized);
            TempData.Remove("PendingLogin");

            var userDto = await _apiClient.LoginAsync(loginDto!);
            if (userDto == null || string.IsNullOrWhiteSpace(userDto.Token))
            {
                ModelState.AddModelError(string.Empty, "Could not complete sign-in after verification.");
                return View(vm);
            }

            await SignInWithJwtAsync(userDto);

            // limpar ReturnUrl e redirecionar por role (como já fazes)
            var returnUrl = TempData["ReturnUrl"] as string;
            TempData.Remove("ReturnUrl");
            return RedirectByRoleOrHome();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Use the built-in method to sign out, which automatically clears the authentication cookie.
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        // TODO: An Access Denied page for users who are logged in but not authorized for a specific page.
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterDto());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _apiClient.RegisterCompanyAdminAsync(model);

            if (success)
            {
                TempData["SuccessMessage"] = message;
                return RedirectToAction("RegistrationComplete");
            }

            ModelState.AddModelError(string.Empty, message);
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegistrationComplete()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
            {
                return RedirectToAction("Index", "Home");
            }

            var (success, message) = await _apiClient.ConfirmEmailAsync(userId, token);

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
        public IActionResult ForgotPassword()
        {
            return View(new ForgotPasswordViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
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
        public IActionResult ForgotPasswordConfirmation(string message)
        {
            ViewData["Message"] = message;
            return View();
        }


        [AllowAnonymous]
        public IActionResult ResendConfirmationEmail(string? email = null)
        {
            return View(new ResendConfirmationEmailViewModel { Email = email ?? "" });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResendConfirmationEmail(ResendConfirmationEmailViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var (success, _) = await _apiClient.ResendConfirmationEmailAsync(model.Email);

            ViewData["Mensagem"] = success
                ? "Se existir uma conta com esse email, o link de confirmação foi reenviado."
                : "Ocorreu um erro ao tentar reenviar o email de confirmação.";

            return View(model);
        }
       

        private async Task SignInWithJwtAsync(UserDto userDto)
        {
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
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                },
                out _
            );

            // adiciona o token como claim para o JwtForwardingDelegatingHandler
            var identity = (ClaimsIdentity)principal.Identity!;
            identity.AddClaim(new Claim("access_token", userDto.Token));

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                authProperties
            );

            // garante que nesta mesma request User.IsInRole() já reflete as claims
            HttpContext.User = new ClaimsPrincipal(identity);
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