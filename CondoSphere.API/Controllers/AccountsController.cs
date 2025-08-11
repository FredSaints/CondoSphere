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
                return StatusCode(201, new { message = "Company and administrator registered successfully." });
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

            var user = await _userService.GetUserByEmailAsync(loginDto.Email);
            if (user != null) 
            {
                var isConfirmed = await _userService.IsEmailConfirmedAsync(user);

                if (!isConfirmed)
                {
                    return Unauthorized(new { Message = "Not confirmed email" });
                }  
            }
          
            var userDto = await _userService.LoginAsync(loginDto);

            if (userDto == null)
            {
                return Unauthorized(new { Message = "Invalid email or password." });
            }

            return Ok(userDto);
        }

        [HttpPost("IsEmailConfirmed")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailConfirmed([FromBody] EmailDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userService.GetUserByEmailAsync(dto.Email);
            if (user == null)
                return Ok(new { confirmed = false }); // não revelar se existe ou não

            var confirmed = await _userService.IsEmailConfirmedAsync(user);
            return Ok(new { confirmed });
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
                return StatusCode(201, new { message = "Condominium Manager registered successfully." });
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
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return NotFound("User not found.");

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return Ok(new { message = "Email confirmed successfully." });
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
                return Ok(new { message = "If a matching account was found, a password has been set." });
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
                return Ok(new { message = "Your password has been set successfully. You can now log in." });
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

        [HttpGet("available-residents")]
        [Authorize(Roles = RoleConstants.CondoManager)]
        public async Task<IActionResult> GetAvailableResidents()
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var residents = await _userService.GetAvailableResidentsAsync(companyId.Value);
            return Ok(residents);
        }

        [HttpPost("users/{userId}/deactivate")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> DeactivateUser(int userId)
        {
            var adminCompanyId = _currentUserService.CompanyId;
            if (adminCompanyId == null) return Unauthorized();

            var success = await _userService.DeactivateUserAsync(userId, adminCompanyId.Value);
            if (success) return NoContent();

            return BadRequest("Failed to deactivate user.");
        }

        [HttpPost("users/{userId}/activate")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> ActivateUser(int userId)
        {
            var adminCompanyId = _currentUserService.CompanyId;
            if (adminCompanyId == null) return Unauthorized();

            var success = await _userService.ActivateUserAsync(userId, adminCompanyId.Value);
            if (success) return NoContent();

            return BadRequest("Failed to activate user.");
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.ForgotPasswordAsync(dto.Email);

            return Ok(new { message = "If an account with that email exists, a password reset link has been sent." });
        }

        [HttpGet("employees")]
        [Authorize(Roles = RoleConstants.CompanyAdmin + "," + RoleConstants.CondoManager)]
        public async Task<IActionResult> GetAvailableEmployees()
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var employees = await _userService.GetAvailableEmployeesAsync(companyId.Value);
            return Ok(employees);
        }

        [HttpPost("register-employee")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> RegisterEmployee([FromBody] RegisterManagerDto registerDto)
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

            var result = await _userService.RegisterEmployeeAsync(registerDto, companyId.Value);

            if (result.Succeeded)
            {
                return StatusCode(201, new { message = "Employee registered successfully." });
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("ResendConfirmationEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ResendConfirmationEmail([FromBody] EmailDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _userService.ResendConfirmationEmailAsync(dto);
            if (result.Succeeded)
                return Ok(new { message = "Confirmation Email Resent" });

            return BadRequest(result.Errors);
        }
    }
}