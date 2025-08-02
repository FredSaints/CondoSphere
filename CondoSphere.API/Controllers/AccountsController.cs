using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.User;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<CoreUser> _userManager;

        public AccountsController(IUserService userService,
                                  ICurrentUserService currentUserService,
                                  UserManager<CoreUser> userManager)
        {
            _userService = userService;
            _currentUserService = currentUserService;
            _userManager = userManager;
        }

        [HttpGet("company-users")]
        [Authorize(Roles = $"{RoleConstants.CompanyAdmin},{RoleConstants.CondoManager}")]
        public async Task<IActionResult> GetCompanyUsers()
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var users = await _userService.GetCompanyUsersWithRolesAsync(companyId.Value);

            return Ok(users);
        }

        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterCompanyAdmin([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.RegisterCompanyAdminAsync(registerDto);

            if (result.Succeeded)
            {
                return StatusCode(201, new { Message = "Company and administrator registered successfully." });
            }

            foreach (var error in result.Errors)
            {
                var errorKey = !string.IsNullOrEmpty(error.Code) ? error.Code : "RegistrationError";
                ModelState.AddModelError(errorKey, error.Description);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDto = await _userService.LoginAsync(loginDto);

            if (userDto == null)
            {
                return Unauthorized(new { Message = "Invalid email or password." });
            }

            return Ok(userDto);
        }

        [HttpPost("register-manager")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> RegisterManager([FromBody] RegisterManagerDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var result = await _userService.RegisterManagerAsync(registerDto, companyId.Value);

            if (result.Succeeded)
            {
                return StatusCode(201, new { Message = "Condominium Manager registered successfully." });
            }

            foreach (var error in result.Errors)
            {
                var errorKey = !string.IsNullOrEmpty(error.Code) ? error.Code : "RegistrationError";
                ModelState.AddModelError(errorKey, error.Description);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("confirm-email")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(int userId, string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return BadRequest("A valid token is required.");
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var decodedToken = System.Net.WebUtility.UrlDecode(token);
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

            if (result.Succeeded)
            {
                return Content("<h1>Email confirmed successfully!</h1><p>You can now log in.</p>", "text/html");
            }

            return BadRequest("Email could not be confirmed. The link may have expired.");
        }

        [HttpPost("set-password")]
        [AllowAnonymous]
        public async Task<IActionResult> SetPassword([FromBody] SetPasswordDto setPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByIdAsync(setPasswordDto.UserId);
            if (user == null)
            {
                // Do not reveal that the user does not exist.
                // Return a generic success message to prevent user enumeration attacks.
                return Ok(new { Message = "If a matching account was found, a password has been set." });
            }

            var result = await _userManager.ResetPasswordAsync(user, setPasswordDto.Token, setPasswordDto.Password);

            if (result.Succeeded)
            {
                // This is the crucial step: we now confirm their email because they have proven ownership
                // by successfully using the token that was sent there.
                if (!user.EmailConfirmed)
                {
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                }
                return Ok(new { Message = "Your password has been set successfully. You can now log in." });
            }

            // If token is invalid, passwords don't match criteria, etc.
            return BadRequest(result.Errors);
        }

        [HttpGet("managers")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> GetAvailableManagers()
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var managers = await _userService.GetAvailableManagersAsync(companyId.Value);
            return Ok(managers);
        }
    }
}