This file is a merged representation of a subset of the codebase, containing files not matching ignore patterns, combined into a single document by Repomix.

# File Summary

## Purpose
This file contains a packed representation of a subset of the repository's contents that is considered the most important context.
It is designed to be easily consumable by AI systems for analysis, code review,
or other automated processes.

## File Format
The content is organized as follows:
1. This summary section
2. Repository information
3. Directory structure
4. Repository files (if enabled)
5. Multiple file entries, each consisting of:
  a. A header with the file path (## File: path/to/file)
  b. The full contents of the file in a code block

## Usage Guidelines
- This file should be treated as read-only. Any changes should be made to the
  original repository files, not this packed version.
- When processing this file, use the file path to distinguish
  between different files in the repository.
- Be aware that this file may contain sensitive information. Handle it with
  the same level of security as you would the original repository.

## Notes
- Some files may have been excluded based on .gitignore rules and Repomix's configuration
- Binary files are not included in this packed representation. Please refer to the Repository Structure section for a complete list of file paths, including binary files
- Files matching these patterns are excluded: **/*.jpg, **/*.png, **/*.csproj, **/*.sln, **/lib/**, **/bin/**, **/obj/**, **/Migrations/**, **/migrations/**, **/*.user, **/.github/**, .gitignore, **/.vs/**
- Files matching patterns in .gitignore are excluded
- Files matching default ignore patterns are excluded
- Files are sorted by Git change count (files with more changes are at the bottom)

# Directory Structure
```
CondoSphere.API/appsettings.Development.json
CondoSphere.API/appsettings.json
CondoSphere.API/CondoSphere.API.http
CondoSphere.API/Controllers/AccountsController.cs
CondoSphere.API/Controllers/CondominiumsController.cs
CondoSphere.API/Controllers/InterventionsController.cs
CondoSphere.API/Controllers/OccurrencesController.cs
CondoSphere.API/Controllers/ProfileController.cs
CondoSphere.API/Controllers/ResidentsController.cs
CondoSphere.API/Controllers/UnitsController.cs
CondoSphere.API/Program.cs
CondoSphere.API/Properties/launchSettings.json
CondoSphere.Application/Authorization/CanAccessOccurrenceRequirement.cs
CondoSphere.Application/Authorization/CanManageInterventionRequirement.cs
CondoSphere.Application/Authorization/IsCondoManagerRequirement.cs
CondoSphere.Application/Interfaces/ICompanyRepository.cs
CondoSphere.Application/Interfaces/ICondominiumRepository.cs
CondoSphere.Application/Interfaces/ICurrentUserService.cs
CondoSphere.Application/Interfaces/IInterventionRepository.cs
CondoSphere.Application/Interfaces/IMailService.cs
CondoSphere.Application/Interfaces/IOccurrenceRepository.cs
CondoSphere.Application/Interfaces/IUnitOfWork.cs
CondoSphere.Application/Interfaces/IUnitRepository.cs
CondoSphere.Application/Interfaces/IUserRepository.cs
CondoSphere.Application/Mappings/CondominiumProfile.cs
CondoSphere.Application/Mappings/InterventionProfile.cs
CondoSphere.Application/Mappings/OccurrenceProfile.cs
CondoSphere.Application/Mappings/UnitProfile.cs
CondoSphere.Application/Services/Condominium/CondominiumService.cs
CondoSphere.Application/Services/Condominium/ICondominiumService.cs
CondoSphere.Application/Services/Condominium/IUnitService.cs
CondoSphere.Application/Services/Condominium/UnitService.cs
CondoSphere.Application/Services/Intervention/IInterventionService.cs
CondoSphere.Application/Services/Intervention/InterventionService.cs
CondoSphere.Application/Services/Occurrence/IOccurrenceService.cs
CondoSphere.Application/Services/Occurrence/OccurrenceService.cs
CondoSphere.Application/Services/Token/ITokenService.cs
CondoSphere.Application/Services/Token/TokenService.cs
CondoSphere.Application/Services/User/IUserService.cs
CondoSphere.Application/Services/User/UserService.cs
CondoSphere.Application/Validators/Condominiums/CreateUpdateCondominiumDtoValidator.cs
CondoSphere.Application/Validators/Condominiums/CreateUpdateUnitDtoValidator.cs
CondoSphere.Core/DTOs/Account/AssignManagerDto.cs
CondoSphere.Core/DTOs/Account/AssignResidentDto.cs
CondoSphere.Core/DTOs/Account/ChangePasswordDto.cs
CondoSphere.Core/DTOs/Account/ForgotPasswordDto.cs
CondoSphere.Core/DTOs/Account/LoginDto.cs
CondoSphere.Core/DTOs/Account/RegisterDto.cs
CondoSphere.Core/DTOs/Account/RegisterManagerDto.cs
CondoSphere.Core/DTOs/Account/RegisterResidentDto.cs
CondoSphere.Core/DTOs/Account/SetPasswordDto.cs
CondoSphere.Core/DTOs/Account/UpdateProfileDto.cs
CondoSphere.Core/DTOs/Account/UserDto.cs
CondoSphere.Core/DTOs/Account/UserListDto.cs
CondoSphere.Core/DTOs/Account/UserProfileDto.cs
CondoSphere.Core/DTOs/Condominiums/CondominiumDto.cs
CondoSphere.Core/DTOs/Condominiums/CreateUpdateCondominiumDto.cs
CondoSphere.Core/DTOs/Condominiums/CreateUpdateUnitDto.cs
CondoSphere.Core/DTOs/Condominiums/UnitDto.cs
CondoSphere.Core/DTOs/Interventions/CreateInterventionDto.cs
CondoSphere.Core/DTOs/Interventions/InterventionDto.cs
CondoSphere.Core/DTOs/Interventions/UpdateInterventionStatusDto.cs
CondoSphere.Core/DTOs/Occurrences/CreateOccurrenceDto.cs
CondoSphere.Core/DTOs/Occurrences/OccurrenceDto.cs
CondoSphere.Core/DTOs/Occurrences/UpdateOccurrenceStatusDto.cs
CondoSphere.Core/Entities/Condominiums/Assembly.cs
CondoSphere.Core/Entities/Condominiums/Condominium.cs
CondoSphere.Core/Entities/Condominiums/Document.cs
CondoSphere.Core/Entities/Condominiums/Intervention.cs
CondoSphere.Core/Entities/Condominiums/Occurrence.cs
CondoSphere.Core/Entities/Condominiums/Unit.cs
CondoSphere.Core/Entities/Financials/Expense.cs
CondoSphere.Core/Entities/Financials/QuotaPayment.cs
CondoSphere.Core/Entities/Financials/Receipt.cs
CondoSphere.Core/Entities/Financials/UnitQuota.cs
CondoSphere.Core/Entities/Users/Company.cs
CondoSphere.Core/Entities/Users/Notification.cs
CondoSphere.Core/Entities/Users/User.cs
CondoSphere.Core/Enums/InterventionStatus.cs
CondoSphere.Core/Enums/OccurrenceStatus.cs
CondoSphere.Core/Enums/SystemRole.cs
CondoSphere.Core/Enums/UnitQuotaStatus.cs
CondoSphere.Core/IEntity.cs
CondoSphere.Core/Response.cs
CondoSphere.Core/RoleConstants.cs
CondoSphere.Core/ValidationAttributes/DateNotInPastAttribute.cs
CondoSphere.Infrastructure/Authorization/CanAccessOccurrenceHandler.cs
CondoSphere.Infrastructure/Authorization/CanManageInterventionHandler.cs
CondoSphere.Infrastructure/Authorization/IsCondoManagerHandler.cs
CondoSphere.Infrastructure/Data/CondominiumDbContext.cs
CondoSphere.Infrastructure/Data/SeedDb.cs
CondoSphere.Infrastructure/Data/UserManagementDbContext.cs
CondoSphere.Infrastructure/Repositories/CompanyRepository.cs
CondoSphere.Infrastructure/Repositories/CondominiumRepository.cs
CondoSphere.Infrastructure/Repositories/InterventionRepository.cs
CondoSphere.Infrastructure/Repositories/OccurrenceRepository.cs
CondoSphere.Infrastructure/Repositories/UnitOfWork.cs
CondoSphere.Infrastructure/Repositories/UnitRepository.cs
CondoSphere.Infrastructure/Repositories/UserRepository.cs
CondoSphere.Infrastructure/Services/CurrentUserService.cs
CondoSphere.Infrastructure/Services/MailService.cs
CondoSphere.Web/appsettings.Development.json
CondoSphere.Web/appsettings.json
CondoSphere.Web/Controllers/AccountController.cs
CondoSphere.Web/Controllers/AdministrationController.cs
CondoSphere.Web/Controllers/CondoManagementController.cs
CondoSphere.Web/Controllers/EmployeeController.cs
CondoSphere.Web/Controllers/HomeController.cs
CondoSphere.Web/Controllers/PortalController.cs
CondoSphere.Web/Controllers/ProfileController.cs
CondoSphere.Web/Models/AssignManagerViewModel.cs
CondoSphere.Web/Models/AssignResidentViewModel.cs
CondoSphere.Web/Models/ChangePasswordViewModel.cs
CondoSphere.Web/Models/CondominiumDetailsViewModel.cs
CondoSphere.Web/Models/EmployeeInterventionViewModel.cs
CondoSphere.Web/Models/ErrorViewModel.cs
CondoSphere.Web/Models/ForgotPasswordViewModel.cs
CondoSphere.Web/Models/InterventionDetailsViewModel.cs
CondoSphere.Web/Models/ManagementDashboardViewModel.cs
CondoSphere.Web/Models/MyProfileViewModel.cs
CondoSphere.Web/Models/OccurrenceDetailsViewModel.cs
CondoSphere.Web/Models/PortalDashboardViewModel.cs
CondoSphere.Web/Models/RegisterResidentViewModel.cs
CondoSphere.Web/Program.cs
CondoSphere.Web/Properties/launchSettings.json
CondoSphere.Web/Services/ApiClient.cs
CondoSphere.Web/Services/IImageService.cs
CondoSphere.Web/Services/ImageService.cs
CondoSphere.Web/Services/JwtForwardingDelegatingHandler.cs
CondoSphere.Web/Views/_ViewImports.cshtml
CondoSphere.Web/Views/_ViewStart.cshtml
CondoSphere.Web/Views/Account/ForgotPassword.cshtml
CondoSphere.Web/Views/Account/ForgotPasswordConfirmation.cshtml
CondoSphere.Web/Views/Account/Login.cshtml
CondoSphere.Web/Views/Account/Register.cshtml
CondoSphere.Web/Views/Account/RegistrationComplete.cshtml
CondoSphere.Web/Views/Account/SetPassword.cshtml
CondoSphere.Web/Views/Administration/AssignManager.cshtml
CondoSphere.Web/Views/Administration/CreateCondominium.cshtml
CondoSphere.Web/Views/Administration/Index.cshtml
CondoSphere.Web/Views/Administration/RegisterEmployee.cshtml
CondoSphere.Web/Views/Administration/RegisterManager.cshtml
CondoSphere.Web/Views/CondoManagement/AssignResident.cshtml
CondoSphere.Web/Views/CondoManagement/CreateUnit.cshtml
CondoSphere.Web/Views/CondoManagement/Details.cshtml
CondoSphere.Web/Views/CondoManagement/Index.cshtml
CondoSphere.Web/Views/CondoManagement/OccurrenceDetails.cshtml
CondoSphere.Web/Views/CondoManagement/RegisterResident.cshtml
CondoSphere.Web/Views/Employee/Details.cshtml
CondoSphere.Web/Views/Employee/Index.cshtml
CondoSphere.Web/Views/Home/Index.cshtml
CondoSphere.Web/Views/Home/Privacy.cshtml
CondoSphere.Web/Views/Portal/CreateOccurrence.cshtml
CondoSphere.Web/Views/Portal/Details.cshtml
CondoSphere.Web/Views/Portal/Index.cshtml
CondoSphere.Web/Views/Profile/ChangePassword.cshtml
CondoSphere.Web/Views/Profile/Index.cshtml
CondoSphere.Web/Views/Shared/_Layout.cshtml
CondoSphere.Web/Views/Shared/_Layout.cshtml.css
CondoSphere.Web/Views/Shared/_LoginPartial.cshtml
CondoSphere.Web/Views/Shared/_ValidationScriptsPartial.cshtml
CondoSphere.Web/Views/Shared/Error.cshtml
CondoSphere.Web/wwwroot/css/site.css
CondoSphere.Web/wwwroot/js/site.js
```

# Files

## File: CondoSphere.API/appsettings.Development.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "UserManagementConnection": "Server=(LocalDb)\\MSSQLLocalDB;Database=CondoSphere_UserManagementDB;Trusted_Connection=True;",
    "CondominiumConnection": "Server=(LocalDb)\\MSSQLLocalDB;Database=CondoSphere_CondominiumDB;Trusted_Connection=True;"
  },
  "MailSettings": {
    "From": "condosphere.geral@gmail.com",
    "Smtp": "smtp.gmail.com",
    "Port": 587,
    "Username": "condosphere.geral@gmail.com"
  },
  "FileUpload": {
    "Path": "C:\\Projectos\\CondoSphere\\CondoSphere_Uploads\\"
  }
}
```

## File: CondoSphere.API/appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## File: CondoSphere.API/CondoSphere.API.http
```
@CondoSphere.API_HostAddress = https://localhost:7177

### REGISTER A NEW COMPANY AND ADMIN ###

POST {{CondoSphere.API_HostAddress}}/api/accounts/register-admin
Content-Type: application/json

{
  "companyName": "My New Test Company",
  "firstName": "Test",
  "lastName": "Admin",
  "email": "admin@admin.com",
  "password": "123456",
  "confirmPassword": "123456"
}
```

## File: CondoSphere.API/Controllers/AccountsController.cs
```csharp
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
    }
}
```

## File: CondoSphere.API/Controllers/CondominiumsController.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Condominium;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CondominiumsController : ControllerBase
    {
        private readonly ICondominiumService _condominiumService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IValidator<CreateUpdateCondominiumDto> _validator;

        public CondominiumsController(
            ICondominiumService condominiumService,
            ICurrentUserService currentUserService,
             IValidator<CreateUpdateCondominiumDto> validator)
        {
            _condominiumService = condominiumService;
            _currentUserService = currentUserService;
            _validator = validator;
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var condominiums = await _condominiumService.GetAllCondominiumsAsync(companyId.Value, pageNumber, pageSize);
            return Ok(condominiums);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var condominium = await _condominiumService.GetCondominiumByIdAsync(id, companyId.Value);

            if (condominium == null)
            {
                return NotFound();
            }
            return Ok(condominium);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> Create([FromBody] CreateUpdateCondominiumDto condominiumDto)
        {
            var validationResult = await _validator.ValidateAsync(condominiumDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var newCondominium = await _condominiumService.CreateCondominiumAsync(condominiumDto, companyId.Value);

            return CreatedAtAction(nameof(GetById), new { id = newCondominium.Id }, newCondominium);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateUpdateCondominiumDto condominiumDto)
        {
            var validationResult = await _validator.ValidateAsync(condominiumDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var success = await _condominiumService.UpdateCondominiumAsync(id, condominiumDto, companyId.Value);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> Delete(int id)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var success = await _condominiumService.DeleteCondominiumAsync(id, companyId.Value);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch("{condominiumId}/assign-manager")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> AssignManager(int condominiumId, [FromBody] AssignManagerDto dto)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            // We use the manager ID from the request body (dto.ManagerId)
            var success = await _condominiumService.AssignManagerAsync(condominiumId, dto.ManagerId, companyId.Value);

            if (!success)
            {
                return BadRequest(new { message = "Failed to assign manager. Verify condominium and manager IDs are valid for your company." });
            }

            return NoContent();
        }

        [HttpGet("my-managed")]
        [Authorize(Roles = RoleConstants.CondoManager)]
        public async Task<IActionResult> GetMyManagedCondominiums()
        {
            var managerId = _currentUserService.UserId;
            if (managerId == null)
            {
                return Unauthorized("User ID is missing from the token.");
            }

            // We need a new service method for this. Let's add it.
            var condominiums = await _condominiumService.GetCondominiumsByManagerIdAsync(managerId.Value);

            return Ok(condominiums);
        }
    }
}
```

## File: CondoSphere.API/Controllers/InterventionsController.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Intervention;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Authorize]
    public class InterventionsController : ControllerBase
    {
        private readonly IInterventionService _interventionService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IOccurrenceRepository _occurrenceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InterventionsController(
            IInterventionService interventionService,
            ICurrentUserService currentUserService,
            IAuthorizationService authorizationService,
            IOccurrenceRepository occurrenceRepository,
            IUnitOfWork unitOfWork)
        {
            _interventionService = interventionService;
            _currentUserService = currentUserService;
            _authorizationService = authorizationService;
            _occurrenceRepository = occurrenceRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("api/interventions")]
        [Authorize(Roles = RoleConstants.CondoManager + "," + RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> CreateIntervention([FromBody] CreateInterventionDto dto)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            var newIntervention = await _interventionService.CreateInterventionAsync(dto, companyId.Value);
            if (newIntervention == null)
            {
                return BadRequest("Invalid Occurrence ID or permission denied.");
            }

            return Ok(newIntervention);
        }

        [HttpGet("api/occurrences/{occurrenceId}/interventions")]
        public async Task<IActionResult> GetInterventionsForOccurrence(int occurrenceId)
        {
            var parentOccurrence = await _occurrenceRepository.GetByIdAsync(occurrenceId);
            if (parentOccurrence == null) return NotFound();

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, parentOccurrence, "CanAccessOccurrence");
            if (!authorizationResult.Succeeded) return Forbid();

            var interventions = await _interventionService.GetInterventionsForOccurrenceAsync(occurrenceId);
            return Ok(interventions);
        }

        [HttpGet("api/interventions/my-tasks")]
        [Authorize(Roles = RoleConstants.Employee)]
        public async Task<IActionResult> GetMyTasks()
        {
            var employeeId = _currentUserService.UserId;
            if (employeeId == null)
            {
                return Unauthorized("User ID could not be determined from token.");
            }

            var interventions = await _interventionService.GetMyInterventionsAsync(employeeId.Value);
            return Ok(interventions);
        }

        [HttpPatch("api/interventions/{id}/status")]
        [Authorize]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateInterventionStatusDto dto)
        {
            var intervention = await _unitOfWork.Interventions.GetByIdAsync(id);
            if (intervention == null)
            {
                return NotFound();
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, intervention, "CanManageIntervention");
            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            var success = await _interventionService.UpdateInterventionStatusAsync(id, dto.Status);

            if (success)
            {
                return NoContent();
            }
            return BadRequest("Failed to update status.");
        }
    }
}
```

## File: CondoSphere.API/Controllers/OccurrencesController.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Occurrence;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Occurrences;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoreOccurrence = CondoSphere.Core.Entities.Condominiums.Occurrence;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/occurrences")]
    [Authorize]
    public class OccurrencesController : ControllerBase
    {
        private readonly IOccurrenceService _occurrenceService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IOccurrenceRepository _occurrenceRepository;

        public OccurrencesController(
            IOccurrenceService occurrenceService,
            ICurrentUserService currentUserService,
            IAuthorizationService authorizationService,
            IOccurrenceRepository occurrenceRepository)
        {
            _occurrenceService = occurrenceService;
            _currentUserService = currentUserService;
            _authorizationService = authorizationService;
            _occurrenceRepository = occurrenceRepository;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var occurrence = await _occurrenceRepository.GetByIdAsync(id);
            if (occurrence == null) return NotFound();

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, occurrence, "CanAccessOccurrence");
            if (!authorizationResult.Succeeded) return Forbid();

            var occurrenceDto = await _occurrenceService.GetOccurrenceByIdAsync(id);
            return Ok(occurrenceDto);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.CondoResident)]
        public async Task<IActionResult> CreateOccurrence([FromForm] CreateOccurrenceDto dto, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var residentUserId = _currentUserService.UserId;
            if (residentUserId == null)
            {
                return Unauthorized("User ID could not be determined from token.");
            }

            var newOccurrenceDto = await _occurrenceService.CreateOccurrenceAsync(dto, residentUserId.Value, imageFile);

            if (newOccurrenceDto == null)
            {
                return BadRequest(new { message = "Could not create occurrence. The user may not be assigned to a unit." });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = newOccurrenceDto.Id },
                newOccurrenceDto);
        }

        [HttpGet("~/api/condominiums/{condominiumId}/occurrences")]
        [Authorize(Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> GetOccurrencesForCondominium(int condominiumId)
        {
            var occurrences = await _occurrenceService.GetOccurrencesForCondominiumAsync(condominiumId);
            return Ok(occurrences);
        }

        [HttpGet("my-occurrences")]
        [Authorize(Roles = RoleConstants.CondoResident)]
        public async Task<IActionResult> GetMyOccurrences()
        {
            var residentUserId = _currentUserService.UserId;
            if (residentUserId == null)
            {
                return Unauthorized("User ID could not be determined from token.");
            }

            var occurrences = await _occurrenceService.GetOccurrencesForResidentAsync(residentUserId.Value);

            return Ok(occurrences);
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateOccurrenceStatusDto dto)
        {
            var occurrence = await _occurrenceRepository.GetByIdAsync(id);
            if (occurrence == null)
            {
                return NotFound();
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, occurrence, "CanAccessOccurrence");
            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            if (User.IsInRole(RoleConstants.CondoResident))
            {
                return Forbid();
            }

            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized();
            }

            var success = await _occurrenceService.UpdateOccurrenceStatusAsync(id, dto.Status, companyId.Value);

            if (success)
            {
                return NoContent();
            }

            return BadRequest("Failed to update status.");
        }
    }
}
```

## File: CondoSphere.API/Controllers/ProfileController.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Token;
using CondoSphere.Application.Services.User;
using CondoSphere.Core.DTOs.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;
        private readonly ITokenService _tokenService;

        public ProfileController(IUserService userService, ICurrentUserService currentUserService, ITokenService tokenService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
            _tokenService = tokenService;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto dto)
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var (success, errors) = await _userService.UpdateProfileAsync(userId.Value, dto);

            if (success)
            {
                var updatedUser = await _userService.GetUserByIdAsync(userId.Value);
                var newToken = await _tokenService.CreateToken(updatedUser);

                return Ok(new
                {
                    message = "Profile updated successfully.",
                    token = newToken
                });
            }
            return BadRequest(errors);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var (success, errors) = await _userService.ChangePasswordAsync(userId.Value, dto);

            if (success) return Ok(new { message = "Password changed successfully." });
            return BadRequest(errors);
        }

        [HttpGet] // Route will be GET /api/profile
        public async Task<IActionResult> GetProfile()
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var profile = await _userService.GetUserProfileAsync(userId.Value);
            if (profile == null) return NotFound();

            return Ok(profile);
        }
    }
}
```

## File: CondoSphere.API/Controllers/ResidentsController.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.User;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/condominiums/{condominiumId}/residents")]
    [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
    public class ResidentsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public ResidentsController(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterResident(int condominiumId, [FromBody] RegisterResidentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                // This should not happen due to the authorization policy, but it's a good safeguard.
                return Unauthorized("Company information is missing from the token.");
            }

            var result = await _userService.RegisterResidentAsync(dto, companyId.Value, condominiumId);

            if (result.Succeeded)
            {
                return StatusCode(201, new { message = "Resident registered successfully. A welcome email has been sent for them to set their password." });
            }

            return BadRequest(result.Errors);
        }
    }
}
```

## File: CondoSphere.API/Controllers/UnitsController.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Condominium;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/condominiums/{condominiumId}/units")]
    [Authorize] // All actions in this controller require an authenticated user.
    public class UnitsController : ControllerBase
    {
        private readonly IUnitService _unitService;
        private readonly IValidator<CreateUpdateUnitDto> _validator;
        private readonly ICurrentUserService _currentUserService;

        public UnitsController(
            IUnitService unitService,
            IValidator<CreateUpdateUnitDto> validator,
            ICurrentUserService currentUserService)
        {
            _unitService = unitService;
            _validator = validator;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        [Authorize(Policy = "IsCondoManagerPolicy")] // Checks if user is CompanyAdmin OR assigned manager.
        public async Task<IActionResult> GetUnitsForCondominium(int condominiumId)
        {
            var units = await _unitService.GetUnitsForCondominiumAsync(condominiumId);
            return Ok(units);
        }

        [HttpGet("{unitId}")]
        [Authorize(Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> GetUnitById(int condominiumId, int unitId)
        {
            var unit = await _unitService.GetUnitByIdAsync(unitId);
            if (unit == null || unit.CondominiumId != condominiumId)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")] // Must be a manager AND be assigned to this condo.
        public async Task<IActionResult> CreateUnit(int condominiumId, [FromBody] CreateUpdateUnitDto unitDto)
        {
            var validationResult = await _validator.ValidateAsync(unitDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var companyId = _currentUserService.CompanyId;
            if (!companyId.HasValue)
            {
                return Forbid(); // Should not be possible if auth has passed, but is a good safeguard.
            }

            var newUnit = await _unitService.CreateUnitAsync(unitDto, condominiumId, companyId.Value);

            return CreatedAtAction(nameof(GetUnitById), new { condominiumId, unitId = newUnit.Id }, newUnit);
        }

        [HttpPut("{unitId}")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> UpdateUnit(int condominiumId, int unitId, [FromBody] CreateUpdateUnitDto unitDto)
        {
            var validationResult = await _validator.ValidateAsync(unitDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var existingUnit = await _unitService.GetUnitByIdAsync(unitId);
            if (existingUnit == null || existingUnit.CondominiumId != condominiumId)
            {
                return NotFound();
            }

            var success = await _unitService.UpdateUnitAsync(unitId, unitDto);
            if (!success)
            {
                return NotFound(); // Or another appropriate error
            }

            return NoContent();
        }

        [HttpDelete("{unitId}")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> DeleteUnit(int condominiumId, int unitId)
        {
            var existingUnit = await _unitService.GetUnitByIdAsync(unitId);
            if (existingUnit == null || existingUnit.CondominiumId != condominiumId)
            {
                return NotFound();
            }

            var success = await _unitService.DeleteUnitAsync(unitId);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch("{unitId}/unassign-resident")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> UnassignResident(int condominiumId, int unitId)
        {
            var unit = await _unitService.GetUnitByIdAsync(unitId);
            if (unit == null || unit.CondominiumId != condominiumId)
            {
                return NotFound();
            }

            var success = await _unitService.UnassignResidentAsync(unitId);

            if (success)
            {
                return NoContent();
            }

            return BadRequest(new { message = "Failed to unassign resident. The unit might already be vacant." });
        }

        [HttpPatch("{unitId}/assign-resident")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> AssignResident(int condominiumId, int unitId, [FromBody] AssignResidentDto dto)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Forbid();

            var success = await _unitService.AssignExistingResidentAsync(unitId, dto.ResidentId, companyId.Value);

            if (success)
            {
                return NoContent();
            }

            return BadRequest(new { message = "Failed to assign resident. The unit may be occupied or the resident invalid." });
        }
    }
}
```

## File: CondoSphere.API/Program.cs
```csharp
using CondoSphere.Application.Authorization;
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Condominium;
using CondoSphere.Application.Services.Intervention;
using CondoSphere.Application.Services.Occurrence;
using CondoSphere.Application.Services.Token;
using CondoSphere.Application.Services.User;
using CondoSphere.Core.Entities.Users;
using CondoSphere.Infrastructure.Authorization;
using CondoSphere.Infrastructure.Data;
using CondoSphere.Infrastructure.Repositories;
using CondoSphere.Infrastructure.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace CondoSphere.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var userManagementConnectionString = builder.Configuration.GetConnectionString("UserManagementConnection");
            var condominiumConnectionString = builder.Configuration.GetConnectionString("CondominiumConnection");

            builder.Services.AddDbContext<UserManagementDbContext>(options =>options.UseSqlServer(userManagementConnectionString));
            builder.Services.AddDbContext<CondominiumDbContext>(options =>options.UseSqlServer(condominiumConnectionString));

            builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                //TODO: Aumentar a segurança da password (por enquanto vamos usar 123456)
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<UserManagementDbContext>()
            .AddDefaultTokenProviders()
            .AddRoles<IdentityRole<int>>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            //Services-----------------------------------------------------------------------------------

            builder.Services.AddTransient<SeedDb>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<ICondominiumRepository, CondominiumRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICondominiumService, CondominiumService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IMailService, MailService>();
            builder.Services.AddScoped<IOccurrenceRepository, OccurrenceRepository>();
            builder.Services.AddScoped<IOccurrenceService, OccurrenceService>();
            builder.Services.AddScoped<IInterventionRepository, InterventionRepository>();
            builder.Services.AddScoped<IInterventionService, InterventionService>();
            builder.Services.AddScoped<IAuthorizationHandler, CanAccessOccurrenceHandler>();
            builder.Services.AddScoped<IAuthorizationHandler, CanManageInterventionHandler>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(CondoSphere.Application.Mappings.CondominiumProfile).Assembly);
                cfg.AddMaps(typeof(CondoSphere.Application.Mappings.OccurrenceProfile).Assembly);
                cfg.AddMaps(typeof(CondoSphere.Application.Mappings.InterventionProfile).Assembly);
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("IsCondoManagerPolicy", policy =>
                    policy.AddRequirements(new IsCondoManagerRequirement()));
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("IsCondoManagerPolicy", policy =>
                    policy.AddRequirements(new IsCondoManagerRequirement()));

                options.AddPolicy("CanAccessOccurrence", policy =>
                    policy.AddRequirements(new CanAccessOccurrenceRequirement()));

                options.AddPolicy("CanManageIntervention", policy =>
                    policy.AddRequirements(new CanManageInterventionRequirement()));

            });

            builder.Services.AddScoped<IAuthorizationHandler, IsCondoManagerHandler>();


            builder.Services.AddControllers();
            builder.Services.AddValidatorsFromAssemblyContaining<CondoSphere.Application.Validators.Condominiums.CreateUpdateCondominiumDtoValidator>();
            builder.Services.AddScoped<IUnitRepository, UnitRepository>();
            builder.Services.AddScoped<IUnitService, UnitService>();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                // 1. Define the security scheme (what kind of security we are using)
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                // 2. Make Swagger UI apply this security scheme to all endpoints that have an [Authorize] attribute
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<SeedDb>();
                await seeder.SeedAsync();
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            var uploadPath = builder.Configuration["FileUpload:Path"];
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(uploadPath),
                RequestPath = "/uploads"
            });


            app.MapControllers();

            app.Run();
        }
    }
}
```

## File: CondoSphere.API/Properties/launchSettings.json
```json
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:48584",
      "sslPort": 44322
    }
  },
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "http://localhost:5263",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "https://localhost:7177;http://localhost:5263",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

## File: CondoSphere.Application/Authorization/CanAccessOccurrenceRequirement.cs
```csharp
using Microsoft.AspNetCore.Authorization;

namespace CondoSphere.Application.Authorization
{
    public class CanAccessOccurrenceRequirement : IAuthorizationRequirement { }
}
```

## File: CondoSphere.Application/Authorization/CanManageInterventionRequirement.cs
```csharp
using Microsoft.AspNetCore.Authorization;

namespace CondoSphere.Application.Authorization
{
    public class CanManageInterventionRequirement : IAuthorizationRequirement { }
}
```

## File: CondoSphere.Application/Authorization/IsCondoManagerRequirement.cs
```csharp
using Microsoft.AspNetCore.Authorization;

namespace CondoSphere.Application.Authorization
{
    /// <summary>
    /// This requirement ensures that the authenticated user is the assigned manager
    /// of the specific condominium they are trying to access.
    /// </summary>
    public class IsCondoManagerRequirement : IAuthorizationRequirement
    {
    }
}
```

## File: CondoSphere.Application/Interfaces/ICompanyRepository.cs
```csharp
using CondoSphere.Core.Entities.Users;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for a repository that manages Company data.
    /// The responsibility for saving changes is handled by the IUnitOfWork.
    /// </summary>
    public interface ICompanyRepository
    {
        Task AddAsync(Company company);
        void Remove(Company company);
    }
}
```

## File: CondoSphere.Application/Interfaces/ICondominiumRepository.cs
```csharp
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for data operations related to Condominiums.
    /// The responsibility for saving changes is handled by the IUnitOfWork.
    /// </summary>
    public interface ICondominiumRepository
    {
        Task AddAsync(Condominium condominium);
        void Update(Condominium condominium);
        void Remove(Condominium condominium);
        Task<Condominium?> GetByIdAsync(int id, int companyId);
        Task<IEnumerable<Condominium>> GetAllAsync(int companyId, int pageNumber, int pageSize);
        Task<IEnumerable<Condominium>> GetByManagerIdAsync(int managerId);
    }
}
```

## File: CondoSphere.Application/Interfaces/ICurrentUserService.cs
```csharp
namespace CondoSphere.Application.Interfaces
{
    public interface ICurrentUserService
    {
        int? UserId { get; }
        int? CompanyId { get; }
        string? UserEmail { get; }
        bool IsInRole(string roleName);
        Task<(bool IsAuthorized, int? CompanyId)> CanManageCondominium(int condominiumId);
    }
}
```

## File: CondoSphere.Application/Interfaces/IInterventionRepository.cs
```csharp
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Interfaces
{
    public interface IInterventionRepository
    {
        Task AddAsync(Intervention intervention);
        Task<IEnumerable<Intervention>> GetByOccurrenceIdAsync(int occurrenceId);
        Task<IEnumerable<Intervention>> GetByAssignedUserIdAsync(int employeeId);
        Task<Intervention?> GetByIdAsync(int interventionId);
        void Update(Intervention intervention);
    }
}
```

## File: CondoSphere.Application/Interfaces/IMailService.cs
```csharp
namespace CondoSphere.Application.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }
}
```

## File: CondoSphere.Application/Interfaces/IOccurrenceRepository.cs
```csharp
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Interfaces
{
    public interface IOccurrenceRepository
    {
        Task<IEnumerable<Occurrence>> GetAllForCondominiumAsync(int condominiumId);
        Task<Occurrence?> GetByIdAsync(int occurrenceId);
        Task AddAsync(Occurrence occurrence);
        Task<IEnumerable<Occurrence>> GetAllForResidentAsync(int residentUserId);
        void Update(Occurrence occurrence);
    }
}
```

## File: CondoSphere.Application/Interfaces/IUnitOfWork.cs
```csharp
namespace CondoSphere.Application.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICompanyRepository Companies { get; }
        IUserRepository Users { get; }
        ICondominiumRepository Condominiums { get; }
        IUnitRepository Units { get; }
        IOccurrenceRepository Occurrences { get; }
        IInterventionRepository Interventions { get; }
        Task<int> CompleteAsync();

    }
}
```

## File: CondoSphere.Application/Interfaces/IUnitRepository.cs
```csharp
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Interfaces
{
    public interface IUnitRepository
    {
        Task AddAsync(Unit unit);
        void Update(Unit unit);
        void Remove(Unit unit);
        Task<Unit?> GetByIdAsync(int unitId);
        Task<IEnumerable<Unit>> GetAllAsync(int condominiumId);
        Task<IEnumerable<int>> GetOccupiedUnitResidentIdsAsync(int companyId);
        Task<Unit?> GetUnitByResidentIdAsync(int residentId);
    }
}
```

## File: CondoSphere.Application/Interfaces/IUserRepository.cs
```csharp
using CondoSphere.Core.DTOs.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondoSphere.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserListDto>> GetCompanyUsersWithRolesAsync(int companyId);
        Task<IEnumerable<UserListDto>> GetUsersInRoleAsync(string roleName, int companyId);
    }
}
```

## File: CondoSphere.Application/Mappings/CondominiumProfile.cs
```csharp
using AutoMapper;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Mappings
{
    public class CondominiumProfile : Profile
    {
        public CondominiumProfile()
        {
            // This defines a map from the Condominium entity to the CondominiumDto.
            // AutoMapper is smart enough to map properties with the same name automatically.
            CreateMap<Condominium, CondominiumDto>();

            // This defines a map from the CreateUpdateCondominiumDto to the Condominium entity.
            // This will be used when creating or updating a condominium.
            CreateMap<CreateUpdateCondominiumDto, Condominium>();
        }
    }
}
```

## File: CondoSphere.Application/Mappings/InterventionProfile.cs
```csharp
using AutoMapper;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Mappings
{
    public class InterventionProfile : Profile
    {
        public InterventionProfile()
        {
            CreateMap<Intervention, InterventionDto>();
            CreateMap<CreateInterventionDto, Intervention>();
        }
    }
}
```

## File: CondoSphere.Application/Mappings/OccurrenceProfile.cs
```csharp
using AutoMapper;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Mappings
{
    public class OccurrenceProfile : Profile
    {
        public OccurrenceProfile()
        {
            CreateMap<Occurrence, OccurrenceDto>();
            CreateMap<CreateOccurrenceDto, Occurrence>();
        }
    }
}
```

## File: CondoSphere.Application/Mappings/UnitProfile.cs
```csharp
using AutoMapper;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Mappings
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<Unit, UnitDto>();
            CreateMap<CreateUpdateUnitDto, Unit>();
        }
    }
}
```

## File: CondoSphere.Application/Services/Condominium/CondominiumService.cs
```csharp
using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Condominiums;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CoreCondominium = CondoSphere.Core.Entities.Condominiums.Condominium;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Condominium
{
    public class CondominiumService : ICondominiumService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<CoreUser> _userManager;
        private readonly IMapper _mapper;

        public CondominiumService(
            IUnitOfWork unitOfWork,
            UserManager<CoreUser> userManager,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CondominiumDto> CreateCondominiumAsync(CreateUpdateCondominiumDto condominiumDto, int companyId)
        {
            var condominium = _mapper.Map<CoreCondominium>(condominiumDto);
            condominium.CompanyId = companyId;

            await _unitOfWork.Condominiums.AddAsync(condominium);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<CondominiumDto>(condominium);
        }

        public async Task<IEnumerable<CondominiumDto>> GetAllCondominiumsAsync(int companyId, int pageNumber, int pageSize)
        {
            // 1. Fetch the raw condominium data from the repository via UnitOfWork
            var condominiums = await _unitOfWork.Condominiums.GetAllAsync(companyId, pageNumber, pageSize);
            if (!condominiums.Any())
            {
                return Enumerable.Empty<CondominiumDto>();
            }

            // 2. Map the entities to DTOs
            var condominiumDtos = _mapper.Map<List<CondominiumDto>>(condominiums);

            // 3. Efficiently fetch the names for all required managers in a single query
            var managerIds = condominiums
                .Where(c => c.ManagerId.HasValue)
                .Select(c => c.ManagerId.Value)
                .Distinct()
                .ToList();

            if (managerIds.Any())
            {
                var managers = await _userManager.Users
                    .Where(u => managerIds.Contains(u.Id))
                    .ToDictionaryAsync(u => u.Id, u => $"{u.FirstName} {u.LastName}");

                foreach (var dto in condominiumDtos)
                {
                    var condo = condominiums.First(c => c.Id == dto.Id);
                    if (condo.ManagerId.HasValue && managers.ContainsKey(condo.ManagerId.Value))
                    {
                        dto.ManagerName = managers[condo.ManagerId.Value];
                    }
                }
            }

            return condominiumDtos;
        }

        public async Task<CondominiumDto?> GetCondominiumByIdAsync(int id, int companyId)
        {
            var condominium = await _unitOfWork.Condominiums.GetByIdAsync(id, companyId);
            return _mapper.Map<CondominiumDto>(condominium);
        }

        public async Task<bool> UpdateCondominiumAsync(int id, CreateUpdateCondominiumDto condominiumDto, int companyId)
        {
            var condominium = await _unitOfWork.Condominiums.GetByIdAsync(id, companyId);
            if (condominium == null)
            {
                return false;
            }

            _mapper.Map(condominiumDto, condominium);

            _unitOfWork.Condominiums.Update(condominium);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteCondominiumAsync(int id, int companyId)
        {
            var condominium = await _unitOfWork.Condominiums.GetByIdAsync(id, companyId);
            if (condominium == null)
            {
                return false;
            }

            _unitOfWork.Condominiums.Remove(condominium);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> AssignManagerAsync(int condominiumId, int managerId, int companyId)
        {
            var condominium = await _unitOfWork.Condominiums.GetByIdAsync(condominiumId, companyId);
            if (condominium == null) return false;

            var manager = await _userManager.FindByIdAsync(managerId.ToString());
            if (manager == null || manager.CompanyId != companyId) return false;

            var roles = await _userManager.GetRolesAsync(manager);
            if (!roles.Contains(RoleConstants.CondoManager)) return false;

            condominium.ManagerId = managerId;
            _unitOfWork.Condominiums.Update(condominium);

            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<CondominiumDto>> GetCondominiumsByManagerIdAsync(int managerId)
        {
            var condominiums = await _unitOfWork.Condominiums.GetByManagerIdAsync(managerId);
            return _mapper.Map<IEnumerable<CondominiumDto>>(condominiums);
        }
    }
}
```

## File: CondoSphere.Application/Services/Condominium/ICondominiumService.cs
```csharp
using CondoSphere.Core.DTOs.Condominiums;

namespace CondoSphere.Application.Services.Condominium
{
    public interface ICondominiumService
    {
        Task<CondominiumDto?> GetCondominiumByIdAsync(int id, int companyId);
        Task<IEnumerable<CondominiumDto>> GetAllCondominiumsAsync(int companyId, int pageNumber, int pageSize);
        Task<CondominiumDto> CreateCondominiumAsync(CreateUpdateCondominiumDto condominiumDto, int companyId);
        Task<bool> UpdateCondominiumAsync(int id, CreateUpdateCondominiumDto condominiumDto, int companyId);
        Task<bool> DeleteCondominiumAsync(int id, int companyId);
        Task<bool> AssignManagerAsync(int condominiumId, int managerId, int companyId);
        Task<IEnumerable<CondominiumDto>> GetCondominiumsByManagerIdAsync(int managerId);
    }
}
```

## File: CondoSphere.Application/Services/Condominium/IUnitService.cs
```csharp
using CondoSphere.Core.DTOs.Condominiums;

namespace CondoSphere.Application.Services.Condominium
{
    public interface IUnitService
    {
        Task<IEnumerable<UnitDto>> GetUnitsForCondominiumAsync(int condominiumId);
        Task<UnitDto?> GetUnitByIdAsync(int unitId);
        Task<UnitDto> CreateUnitAsync(CreateUpdateUnitDto unitDto, int condominiumId, int companyId);
        Task<bool> UpdateUnitAsync(int unitId, CreateUpdateUnitDto unitDto);
        Task<bool> DeleteUnitAsync(int unitId);
        Task<bool> UnassignResidentAsync(int unitId);
        Task<bool> AssignExistingResidentAsync(int unitId, int residentId, int companyId);
    }
}
```

## File: CondoSphere.Application/Services/Condominium/UnitService.cs
```csharp
using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Condominiums;
using Microsoft.AspNetCore.Identity;
using CoreUnit = CondoSphere.Core.Entities.Condominiums.Unit;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Condominium
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<CoreUser> _userManager;

        public UnitService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<CoreUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UnitDto> CreateUnitAsync(CreateUpdateUnitDto unitDto, int condominiumId, int companyId)
        {
            var unit = _mapper.Map<CoreUnit>(unitDto);
            unit.CondominiumId = condominiumId;
            unit.CompanyId = companyId;

            await _unitOfWork.Units.AddAsync(unit);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<UnitDto>(unit);
        }

        public async Task<bool> DeleteUnitAsync(int unitId)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(unitId);
            if (unit == null) return false;

            _unitOfWork.Units.Remove(unit);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<UnitDto?> GetUnitByIdAsync(int unitId)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(unitId);
            return _mapper.Map<UnitDto>(unit);
        }

        public async Task<IEnumerable<UnitDto>> GetUnitsForCondominiumAsync(int condominiumId)
        {
            var units = await _unitOfWork.Units.GetAllAsync(condominiumId);
            return _mapper.Map<IEnumerable<UnitDto>>(units);
        }

        public async Task<bool> UpdateUnitAsync(int unitId, CreateUpdateUnitDto unitDto)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(unitId);
            if (unit == null) return false;

            _mapper.Map(unitDto, unit);
            _unitOfWork.Units.Update(unit);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> UnassignResidentAsync(int unitId)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(unitId);
            if (unit?.ResidentId == null)
            {
                return false;
            }
            unit.ResidentId = null;
            _unitOfWork.Units.Update(unit);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> AssignExistingResidentAsync(int unitId, int residentId, int companyId)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(unitId);
            if (unit == null || unit.CompanyId != companyId || unit.ResidentId.HasValue)
            {
                return false;
            }

            var resident = await _userManager.FindByIdAsync(residentId.ToString());
            if (resident == null || resident.CompanyId != companyId)
            {
                return false;
            }

            if (!await _userManager.IsInRoleAsync(resident, RoleConstants.CondoResident))
            {
                return false;
            }

            unit.ResidentId = residentId;
            _unitOfWork.Units.Update(unit);

            // If a resident is assigned, ensure their account is active.
            if (!resident.IsActive)
            {
                resident.IsActive = true;
                await _userManager.UpdateAsync(resident);
            }

            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
```

## File: CondoSphere.Application/Services/Intervention/IInterventionService.cs
```csharp
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.Enums;

namespace CondoSphere.Application.Services.Intervention
{
    public interface IInterventionService
    {
        Task<InterventionDto?> CreateInterventionAsync(CreateInterventionDto dto, int managerCompanyId);
        Task<IEnumerable<InterventionDto>> GetInterventionsForOccurrenceAsync(int occurrenceId);
        Task<IEnumerable<InterventionDto>> GetMyInterventionsAsync(int employeeId);
        Task<bool> UpdateInterventionStatusAsync(int interventionId, InterventionStatus newStatus);
    }
}
```

## File: CondoSphere.Application/Services/Intervention/InterventionService.cs
```csharp
using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CoreIntervention = CondoSphere.Core.Entities.Condominiums.Intervention;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Intervention
{
    public class InterventionService : IInterventionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<CoreUser> _userManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly ICurrentUserService _currentUserService;

        public InterventionService(
            IUnitOfWork unitOfWork,
            IMapper mapper, UserManager<CoreUser> userManager,
            IAuthorizationService authorizationService,
            ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _authorizationService = authorizationService;
            _currentUserService = currentUserService;
        }

        public async Task<InterventionDto?> CreateInterventionAsync(CreateInterventionDto dto, int managerCompanyId)
        {
            var parentOccurrence = await _unitOfWork.Occurrences.GetByIdAsync(dto.OccurrenceId);
            if (parentOccurrence == null || parentOccurrence.CompanyId != managerCompanyId)
            {
                return null;
            }

            var newIntervention = _mapper.Map<CoreIntervention>(dto);

            newIntervention.Status = InterventionStatus.Scheduled;
            newIntervention.CompanyId = parentOccurrence.CompanyId;
            newIntervention.CondominiumId = parentOccurrence.CondominiumId;
            newIntervention.UnitId = parentOccurrence.UnitId;

            await _unitOfWork.Interventions.AddAsync(newIntervention);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<InterventionDto>(newIntervention);
        }

        public async Task<IEnumerable<InterventionDto>> GetInterventionsForOccurrenceAsync(int occurrenceId)
        {
            var interventions = await _unitOfWork.Interventions.GetByOccurrenceIdAsync(occurrenceId);
            if (!interventions.Any())
            {
                return Enumerable.Empty<InterventionDto>();
            }

            var interventionDtos = _mapper.Map<List<InterventionDto>>(interventions);

            var assignedUserIds = interventions
                .Where(i => i.AssignedToUserId.HasValue)
                .Select(i => i.AssignedToUserId.Value)
                .Distinct()
                .ToList();

            if (assignedUserIds.Any())
            {
                var assignees = await _userManager.Users
                    .Where(u => assignedUserIds.Contains(u.Id))
                    .ToDictionaryAsync(u => u.Id, u => $"{u.FirstName} {u.LastName}");

                foreach (var dto in interventionDtos)
                {
                    if (dto.AssignedToUserId.HasValue && assignees.ContainsKey(dto.AssignedToUserId.Value))
                    {
                        dto.AssignedToUserName = assignees[dto.AssignedToUserId.Value];
                    }
                }
            }
            return interventionDtos;
        }

        public async Task<IEnumerable<InterventionDto>> GetMyInterventionsAsync(int employeeId)
        {
            var interventions = await _unitOfWork.Interventions.GetByAssignedUserIdAsync(employeeId);
            return _mapper.Map<IEnumerable<InterventionDto>>(interventions);
        }

        public async Task<bool> UpdateInterventionStatusAsync(int interventionId, InterventionStatus newStatus)
        {
            var intervention = await _unitOfWork.Interventions.GetByIdAsync(interventionId);
            if (intervention == null)
            {
                return false;
            }

            if (intervention.Status == InterventionStatus.Cancelled)
            {

                return false;
            }

            intervention.Status = newStatus;
            _unitOfWork.Interventions.Update(intervention);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
```

## File: CondoSphere.Application/Services/Occurrence/IOccurrenceService.cs
```csharp
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace CondoSphere.Application.Services.Occurrence
{
    public interface IOccurrenceService
    {
        Task<IEnumerable<OccurrenceDto>> GetOccurrencesForCondominiumAsync(int condominiumId);
        Task<OccurrenceDto?> CreateOccurrenceAsync(CreateOccurrenceDto dto, int residentUserId, IFormFile? imageFile);
        Task<OccurrenceDto?> GetOccurrenceByIdAsync(int occurrenceId);
        Task<IEnumerable<OccurrenceDto>> GetOccurrencesForResidentAsync(int residentUserId);
        Task<bool> UpdateOccurrenceStatusAsync(int occurrenceId, OccurrenceStatus newStatus, int companyId);
    }
}
```

## File: CondoSphere.Application/Services/Occurrence/OccurrenceService.cs
```csharp
using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CoreOccurrence = CondoSphere.Core.Entities.Condominiums.Occurrence;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Occurrence
{
    public class OccurrenceService : IOccurrenceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<CoreUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OccurrenceService(
            IUnitOfWork unitOfWork,
            UserManager<CoreUser> userManager,
            IMapper mapper,
            IConfiguration configuration,
             IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<OccurrenceDto>> GetOccurrencesForCondominiumAsync(int condominiumId)
        {
            var occurrences = await _unitOfWork.Occurrences.GetAllForCondominiumAsync(condominiumId);
            if (!occurrences.Any())
            {
                return Enumerable.Empty<OccurrenceDto>();
            }

            var occurrenceDtos = _mapper.Map<List<OccurrenceDto>>(occurrences);

            var reporterIds = occurrences.Select(o => o.ReportedByUserId).Distinct().ToList();
            var reporters = await _userManager.Users
                .Where(u => reporterIds.Contains(u.Id))
                .ToDictionaryAsync(u => u.Id, u => $"{u.FirstName} {u.LastName}");

            foreach (var dto in occurrenceDtos)
            {
                var originalOccurrence = occurrences.First(o => o.Id == dto.Id);
                if (reporters.ContainsKey(originalOccurrence.ReportedByUserId))
                {
                    dto.ReportedByUserName = reporters[originalOccurrence.ReportedByUserId];
                }
            }

            return occurrenceDtos;
        }

        public async Task<OccurrenceDto?> CreateOccurrenceAsync(CreateOccurrenceDto dto, int residentUserId, IFormFile? imageFile)
        {
            // 1. Find the unit associated with the logged-in resident to get context.
            var unit = await _unitOfWork.Units.GetUnitByResidentIdAsync(residentUserId);
            if (unit == null)
            {
                // Fail because this user is not an active resident of any unit.
                return null;
            }

            // 2. Map the incoming data (Title, Description) to our database entity.
            var newOccurrence = _mapper.Map<CoreOccurrence>(dto);

            // 3. Handle the optional image upload.
            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadPath = _configuration["FileUpload:Path"];
                if (string.IsNullOrEmpty(uploadPath))
                {
                    return null;
                }

                // Create a unique, random filename to prevent name collisions and obscure the original filename.
                var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(uploadPath, uniqueFileName);

                // Save the file stream to the configured physical path on the server's disk.
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                // Get the current HTTP request context to build the base URL (e.g., https://localhost:7177)
                var request = _httpContextAccessor.HttpContext.Request;
                var baseUrl = $"{request.Scheme}://{request.Host}";

                // Combine the base URL with the public path to the file.
                newOccurrence.ImageUrl = $"{baseUrl}/uploads/{uniqueFileName}";
            }

            // 4. Populate the system-managed properties for the new occurrence.
            newOccurrence.ReportedDate = DateTime.UtcNow;
            newOccurrence.Status = OccurrenceStatus.Open;
            newOccurrence.ReportedByUserId = residentUserId;
            newOccurrence.UnitId = unit.Id;
            newOccurrence.CondominiumId = unit.CondominiumId;
            newOccurrence.CompanyId = unit.CompanyId;

            // 5. Add the new entity to the repository and save the changes via the Unit of Work.
            await _unitOfWork.Occurrences.AddAsync(newOccurrence);
            await _unitOfWork.CompleteAsync();

            // 6. Map the fully populated entity (with its new ID and absolute ImageUrl) back to a DTO to return.
            return _mapper.Map<OccurrenceDto>(newOccurrence);
        }

        public async Task<OccurrenceDto?> GetOccurrenceByIdAsync(int occurrenceId)
        {
            var occurrence = await _unitOfWork.Occurrences.GetByIdAsync(occurrenceId);
            if (occurrence == null)
            {
                return null;
            }

            var dto = _mapper.Map<OccurrenceDto>(occurrence);

            var reporter = await _userManager.FindByIdAsync(occurrence.ReportedByUserId.ToString());
            if (reporter != null)
            {
                dto.ReportedByUserName = $"{reporter.FirstName} {reporter.LastName}";
            }

            return dto;
        }

        public async Task<IEnumerable<OccurrenceDto>> GetOccurrencesForResidentAsync(int residentUserId)
        {
            var occurrences = await _unitOfWork.Occurrences.GetAllForResidentAsync(residentUserId);

            return _mapper.Map<IEnumerable<OccurrenceDto>>(occurrences);
        }

        public async Task<bool> UpdateOccurrenceStatusAsync(int occurrenceId, OccurrenceStatus newStatus, int companyId)
        {
            var occurrence = await _unitOfWork.Occurrences.GetByIdAsync(occurrenceId);

            if (occurrence == null || occurrence.CompanyId != companyId)
            {
                return false;
            }

            occurrence.Status = newStatus;

            _unitOfWork.Occurrences.Update(occurrence);

            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
```

## File: CondoSphere.Application/Services/Token/ITokenService.cs
```csharp
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Token
{
    public interface ITokenService
    {
        Task<string> CreateToken(CoreUser user);
    }
}
```

## File: CondoSphere.Application/Services/Token/TokenService.cs
```csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<CoreUser> _userManager;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config, UserManager<CoreUser> userManager)
        {
            _config = config;
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        }

        public async Task<string> CreateToken(CoreUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, user.FirstName ?? string.Empty),
                new Claim(ClaimTypes.Surname, user.LastName ?? string.Empty),

                new Claim("companyId", user.CompanyId.ToString() ?? string.Empty),
                new Claim("profile_picture", user.ProfilePictureUrl ?? string.Empty)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
```

## File: CondoSphere.Application/Services/User/IUserService.cs
```csharp
using CondoSphere.Core.DTOs.Account;
using Microsoft.AspNetCore.Identity;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.User
{
    /// <summary>
    /// Defines the contract for user management services.
    /// </summary>
    public interface IUserService
    {
        Task<IdentityResult> RegisterCompanyAdminAsync(RegisterDto registerDto);
        Task<UserDto?> LoginAsync(LoginDto loginDto);
        Task<IdentityResult> RegisterManagerAsync(RegisterManagerDto registerDto, int companyId);
        Task<IEnumerable<UserListDto>> GetCompanyUsersWithRolesAsync(int companyId);
        Task<IdentityResult> RegisterResidentAsync(RegisterResidentDto dto, int companyId, int condominiumId);
        Task<IEnumerable<UserListDto>> GetAvailableManagersAsync(int companyId);
        Task<IEnumerable<UserListDto>> GetAvailableResidentsAsync(int companyId);
        Task<bool> DeactivateUserAsync(int userIdToDeactivate, int adminCompanyId);
        Task<bool> ActivateUserAsync(int userIdToActivate, int adminCompanyId);
        Task<bool> ForgotPasswordAsync(string email);
        Task<(bool Success, IEnumerable<IdentityError>? Errors)> UpdateProfileAsync(int userId, UpdateProfileDto dto);
        Task<(bool Success, IEnumerable<IdentityError>? Errors)> ChangePasswordAsync(int userId, ChangePasswordDto dto);
        Task<UserProfileDto?> GetUserProfileAsync(int userId);
        Task<CoreUser?> GetUserByIdAsync(int userId);
        Task<IEnumerable<UserListDto>> GetAvailableEmployeesAsync(int companyId);
        Task<IdentityResult> RegisterEmployeeAsync(RegisterManagerDto registerDto, int companyId);
    }
}
```

## File: CondoSphere.Application/Services/User/UserService.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Token;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<CoreUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public UserService(
            UserManager<CoreUser> userManager,
            IUnitOfWork unitOfWork,
            ITokenService tokenService,
            IMailService mailService,
            IConfiguration configuration,
            ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _mailService = mailService;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }

        public async Task<CoreUser?> GetUserByIdAsync(int userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<UserDto?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return null;
            }

            return new UserDto
            {
                FirstName = user.FirstName ?? string.Empty,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user)
            };
        }

        public async Task<IdentityResult> RegisterCompanyAdminAsync(RegisterDto registerDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "An account with this email address already exists." });
            }

            var newCompany = new Company { Name = registerDto.CompanyName, IsActive = true };
            await _unitOfWork.Companies.AddAsync(newCompany);
            await _unitOfWork.CompleteAsync();

            var newUser = new CoreUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.Email,
                CompanyId = newCompany.Id,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(newUser, registerDto.Password);
            if (!result.Succeeded)
            {
                // If user creation fails, we should remove the company we just created.
                _unitOfWork.Companies.Remove(newCompany);
                await _unitOfWork.CompleteAsync();
                return result;
            }

            await _userManager.AddToRoleAsync(newUser, RoleConstants.CompanyAdmin);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            var encodedToken = WebUtility.UrlEncode(token);
            var webAppBaseUrl = _configuration["ClientSettings:WebAppBaseUrl"];
            var confirmationLink = $"{webAppBaseUrl}/Account/ConfirmEmail?userId={newUser.Id}&token={encodedToken}";

            await _mailService.SendEmailAsync(
                newUser.Email,
                "Confirm your CondoSphere Account",
                $"<h1>Welcome to CondoSphere!</h1><p>Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.</p>");

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> RegisterManagerAsync(RegisterManagerDto registerDto, int companyId)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "An account with this email address already exists." });
            }

            var newUser = new CoreUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.Email,
                CompanyId = companyId,
                IsActive = true,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(newUser);
            if (!result.Succeeded)
            {
                return result;
            }

            await _userManager.AddToRoleAsync(newUser, RoleConstants.CondoManager);

            var token = await _userManager.GeneratePasswordResetTokenAsync(newUser);
            var encodedToken = WebUtility.UrlEncode(token);
            var setPasswordLink = $"{_configuration["ClientSettings:WebAppBaseUrl"]}/Account/SetPassword?userId={newUser.Id}&token={encodedToken}";

            await _mailService.SendEmailAsync(
                newUser.Email,
                "You've been invited to CondoSphere - Set Your Password",
                $"<h1>Welcome, Manager!</h1>" +
                $"<p>You have been registered as a Condominium Manager. Please complete your account setup by setting a password.</p>" +
                $"<p><a href='{setPasswordLink}'>Set Your Password</a></p>");

            return IdentityResult.Success;
        }

        public async Task<IEnumerable<UserListDto>> GetCompanyUsersWithRolesAsync(int companyId)
        {
            // Access repositories through the UnitOfWork
            return await _unitOfWork.Users.GetCompanyUsersWithRolesAsync(companyId);
        }

        public async Task<IdentityResult> RegisterResidentAsync(RegisterResidentDto dto, int companyId, int condominiumId)
        {
            // This method now saves changes across both database contexts in a coordinated way.
            var unit = await _unitOfWork.Units.GetByIdAsync(dto.UnitId);
            if (unit == null || unit.CondominiumId != condominiumId)
            {
                return IdentityResult.Failed(new IdentityError { Code = "UnitNotFound", Description = "Unit not found in this condominium." });
            }
            if (unit.ResidentId.HasValue)
            {
                return IdentityResult.Failed(new IdentityError { Code = "UnitOccupied", Description = "This unit already has an assigned resident." });
            }

            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Code = "DuplicateEmail", Description = "An account with this email address already exists." });
            }

            var newUser = new CoreUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.Email,
                CompanyId = companyId,
                IsActive = true,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(newUser);
            if (!result.Succeeded)
            {
                return result;
            }

            await _userManager.AddToRoleAsync(newUser, RoleConstants.CondoResident);

            unit.ResidentId = newUser.Id;
            _unitOfWork.Units.Update(unit);
            await _unitOfWork.CompleteAsync();

            var token = await _userManager.GeneratePasswordResetTokenAsync(newUser);
            var encodedToken = WebUtility.UrlEncode(token);
            var setPasswordLink = $"{_configuration["ClientSettings:WebAppBaseUrl"]}/Account/SetPassword?userId={newUser.Id}&token={encodedToken}";

            await _mailService.SendEmailAsync(
                newUser.Email,
                "Welcome to CondoSphere - Set Your Password",
                $"<h1>Welcome to CondoSphere!</h1>" +
                $"<p>An account has been created for you by your condominium management.</p>" +
                $"<p>Please complete your registration by setting your password. Click the link below to get started:</p>" +
                $"<p><a href='{setPasswordLink}'>Set Your Password</a></p>");

            return IdentityResult.Success;
        }

        public async Task<IEnumerable<UserListDto>> GetAvailableManagersAsync(int companyId)
        {
            // Access repositories through the UnitOfWork
            return await _unitOfWork.Users.GetUsersInRoleAsync(RoleConstants.CondoManager, companyId);
        }

        public async Task<IEnumerable<UserListDto>> GetAvailableResidentsAsync(int companyId)
        {
            // Access repositories through the UnitOfWork
            var allCompanyResidents = await _unitOfWork.Users.GetUsersInRoleAsync(RoleConstants.CondoResident, companyId);
            var occupiedUnitResidentIds = await _unitOfWork.Units.GetOccupiedUnitResidentIdsAsync(companyId);

            var availableResidents = allCompanyResidents
                .Where(resident => !occupiedUnitResidentIds.Contains(resident.Id))
                .ToList();

            return availableResidents;
        }

        public async Task<bool> DeactivateUserAsync(int userIdToDeactivate, int adminCompanyId)
        {
            var userToDeactivate = await _userManager.FindByIdAsync(userIdToDeactivate.ToString());
            if (userToDeactivate == null || userToDeactivate.CompanyId != adminCompanyId)
            {
                return false;
            }
            if (userToDeactivate.Id == _currentUserService.UserId)
            {
                return false; // Cannot deactivate self
            }

            userToDeactivate.IsActive = false;
            var result = await _userManager.UpdateAsync(userToDeactivate);
            if (!result.Succeeded)
            {
                return false;
            }

            // Unassign from unit if they were a resident
            var unit = await _unitOfWork.Units.GetUnitByResidentIdAsync(userIdToDeactivate);
            if (unit != null)
            {
                unit.ResidentId = null;
                _unitOfWork.Units.Update(unit);
                await _unitOfWork.CompleteAsync();
            }

            return true;
        }

        public async Task<bool> ActivateUserAsync(int userIdToActivate, int adminCompanyId)
        {
            var userToActivate = await _userManager.Users
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(u => u.Id == userIdToActivate);

            if (userToActivate == null || userToActivate.CompanyId != adminCompanyId)
            {
                return false;
            }

            userToActivate.IsActive = true;
            var result = await _userManager.UpdateAsync(userToActivate);
            return result.Succeeded;
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !user.EmailConfirmed)
            {
                return true;
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = WebUtility.UrlEncode(token);

            var resetLink = $"{_configuration["ClientSettings:WebAppBaseUrl"]}/Account/SetPassword?userId={user.Id}&token={encodedToken}";

            await _mailService.SendEmailAsync(
                email,
                "Reset Your CondoSphere Password",
                $"<h1>Password Reset Request</h1>" +
                $"<p>Please reset your password by <a href='{resetLink}'>clicking here</a>.</p>" +
                $"<p>If you did not request a password reset, please ignore this email.</p>");

            return true;
        }

        public async Task<(bool Success, IEnumerable<IdentityError>? Errors)> UpdateProfileAsync(int userId, UpdateProfileDto dto)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return (false, new[] { new IdentityError { Description = "User not found." } });

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.ProfilePictureUrl = dto.ProfilePictureUrl;

            var result = await _userManager.UpdateAsync(user);
            return (result.Succeeded, result.Errors);
        }

        public async Task<(bool Success, IEnumerable<IdentityError>? Errors)> ChangePasswordAsync(int userId, ChangePasswordDto dto)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return (false, new[] { new IdentityError { Description = "User not found." } });

            var result = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
            return (result.Succeeded, result.Errors);
        }

        public async Task<UserProfileDto?> GetUserProfileAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return null;

            var roles = await _userManager.GetRolesAsync(user);

            return new UserProfileDto
            {
                Id = user.Id,
                FirstName = user.FirstName ?? "",
                LastName = user.LastName ?? "",
                Email = user.Email,
                ProfilePictureUrl = user.ProfilePictureUrl,
                CompanyId = user.CompanyId,
                Roles = roles
            };
        }

        public async Task<IEnumerable<UserListDto>> GetAvailableEmployeesAsync(int companyId)
        {
            return await _unitOfWork.Users.GetUsersInRoleAsync(RoleConstants.Employee, companyId);
        }

        public async Task<IdentityResult> RegisterEmployeeAsync(RegisterManagerDto registerDto, int companyId)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)

            {
                return IdentityResult.Failed(new IdentityError { Description = "An account with this email address already exists." });
            }

            var newUser = new CoreUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.Email,
                CompanyId = companyId,
                IsActive = true,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(newUser);
            if (!result.Succeeded)
            {
                return result;
            }

            await _userManager.AddToRoleAsync(newUser, RoleConstants.Employee);

            var token = await _userManager.GeneratePasswordResetTokenAsync(newUser);
            var encodedToken = WebUtility.UrlEncode(token);
            var setPasswordLink = $"{_configuration["ClientSettings:WebAppBaseUrl"]}/Account/SetPassword?userId={newUser.Id}&token={encodedToken}";

            await _mailService.SendEmailAsync(
                newUser.Email,
                "You've been invited to CondoSphere - Set Your Password",
                $"<h1>Welcome to the Team!</h1>" +
                $"<p>You have been registered as an Employee. Please complete your account setup by setting a password.</p>" +
                $"<p><a href='{setPasswordLink}'>Set Your Password</a></p>");

            return IdentityResult.Success;
        }
    }
}
```

## File: CondoSphere.Application/Validators/Condominiums/CreateUpdateCondominiumDtoValidator.cs
```csharp
using CondoSphere.Core.DTOs.Condominiums;
using FluentValidation;

namespace CondoSphere.Application.Validators.Condominiums
{
    public class CreateUpdateCondominiumDtoValidator : AbstractValidator<CreateUpdateCondominiumDto>
    {
        public CreateUpdateCondominiumDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(5, 255).WithMessage("Address must be between 5 and 255 characters.");
        }
    }
}
```

## File: CondoSphere.Application/Validators/Condominiums/CreateUpdateUnitDtoValidator.cs
```csharp
using CondoSphere.Core.DTOs.Condominiums;
using FluentValidation;

namespace CondoSphere.Application.Validators.Condominiums
{
    public class CreateUpdateUnitDtoValidator : AbstractValidator<CreateUpdateUnitDto>
    {
        public CreateUpdateUnitDtoValidator()
        {
            RuleFor(x => x.Identifier)
                .NotEmpty().WithMessage("Identifier is required.")
                .MaximumLength(100).WithMessage("Identifier cannot exceed 100 characters.");
        }
    }
}
```

## File: CondoSphere.Core/DTOs/Account/AssignManagerDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    /// <summary>
    /// Represents the data required to assign a manager to a condominium.
    /// </summary>
    public class AssignManagerDto
    {
        /// <summary>
        /// The ID of the User (who must have the CondoManager role) to be assigned.
        /// </summary>
        [Required]
        public int ManagerId { get; set; }
    }
}
```

## File: CondoSphere.Core/DTOs/Account/AssignResidentDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Condominiums
{
    public class AssignResidentDto
    {
        [Required]
        public int ResidentId { get; set; }
    }
}
```

## File: CondoSphere.Core/DTOs/Account/ChangePasswordDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    public class ChangePasswordDto
    {
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Account/ForgotPasswordDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Account/LoginDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Account/RegisterDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    /// <summary>
    /// Represents the data required to register a new company and its first administrator.
    /// </summary>
    public class RegisterDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]//TODO: Aumentar a segurança da password (por enquanto vamos usar 123456)
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Account/RegisterManagerDto.cs
```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.DTOs.Account
{
    /// <summary>
    /// Represents the data required by a Company Admin to register a new Condominium Manager.
    /// </summary>
    public class RegisterManagerDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Account/RegisterResidentDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    public class RegisterResidentDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int UnitId { get; set; }
    }
}
```

## File: CondoSphere.Core/DTOs/Account/SetPasswordDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    public class SetPasswordDto
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Token { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Account/UpdateProfileDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    public class UpdateProfileDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;
        public string? ProfilePictureUrl { get; set; }
    }
}
```

## File: CondoSphere.Core/DTOs/Account/UserDto.cs
```csharp
namespace CondoSphere.Core.DTOs.Account
{
    /// <summary>
    /// Represents the data returned to the client after a successful login.
    /// </summary>
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Account/UserListDto.cs
```csharp
namespace CondoSphere.Core.DTOs.Account
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
```

## File: CondoSphere.Core/DTOs/Account/UserProfileDto.cs
```csharp
namespace CondoSphere.Core.DTOs.Account
{
    // This DTO represents the full profile data we need on the frontend.
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ProfilePictureUrl { get; set; }
        public int? CompanyId { get; set; }
        public IEnumerable<string> Roles { get; set; } = new List<string>();
    }
}
```

## File: CondoSphere.Core/DTOs/Condominiums/CondominiumDto.cs
```csharp
namespace CondoSphere.Core.DTOs.Condominiums
{
    /// <summary>
    /// Represents a condominium when being displayed to the user.
    /// </summary>
    public class CondominiumDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public string? ManagerName { get; set; }
    }
}
```

## File: CondoSphere.Core/DTOs/Condominiums/CreateUpdateCondominiumDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Condominiums
{
    /// <summary>
    /// Represents the data needed to create or update a condominium.
    /// </summary>
    public class CreateUpdateCondominiumDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Address { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Condominiums/CreateUpdateUnitDto.cs
```csharp
namespace CondoSphere.Core.DTOs.Condominiums
{
    /// <summary>
    /// Represents the data needed to create or update a Unit.
    /// </summary>
    public class CreateUpdateUnitDto
    {
        public string Identifier { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Condominiums/UnitDto.cs
```csharp
namespace CondoSphere.Core.DTOs.Condominiums
{
    /// <summary>
    /// Represents a Unit when being displayed to the user.
    /// </summary>
    public class UnitDto
    {
        public int Id { get; set; }
        public string Identifier { get; set; } = string.Empty;
        public int CondominiumId { get; set; }
        public int? ResidentId { get; set; }
    }
}
```

## File: CondoSphere.Core/DTOs/Interventions/CreateInterventionDto.cs
```csharp
using CondoSphere.Core.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Interventions
{
    public class CreateInterventionDto
    {
        [Required]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "The Description must be at least 10 characters long.")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [DateNotInPast]
        public DateTime StartDate { get; set; }

        // The ID of the parent occurrence this intervention is for.
        [Required]
        public int OccurrenceId { get; set; }

        // The ID of the employee assigned.
        [Required(ErrorMessage = "You must assign an employee.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid employee.")]
        public int AssignedToUserId { get; set; }
    }
}
```

## File: CondoSphere.Core/DTOs/Interventions/InterventionDto.cs
```csharp
using CondoSphere.Core.Enums;

namespace CondoSphere.Core.DTOs.Interventions
{
    public class InterventionDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public InterventionStatus Status { get; set; }
        public int OccurrenceId { get; set; }
        public int? AssignedToUserId { get; set; }
        public string? AssignedToUserName { get; set; }
    }
}
```

## File: CondoSphere.Core/DTOs/Interventions/UpdateInterventionStatusDto.cs
```csharp
using CondoSphere.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Interventions
{
    public class UpdateInterventionStatusDto
    {
        [Required]
        [EnumDataType(typeof(InterventionStatus))]
        public InterventionStatus Status { get; set; }
    }
}
```

## File: CondoSphere.Core/DTOs/Occurrences/CreateOccurrenceDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Occurrences
{
    public class CreateOccurrenceDto
    {
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The Title must be between 5 and 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "The Description must be between 10 and 1000 characters.")]
        public string Description { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Occurrences/OccurrenceDto.cs
```csharp
using CondoSphere.Core.Enums;

namespace CondoSphere.Core.DTOs.Occurrences
{
    public class OccurrenceDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReportedDate { get; set; }
        public OccurrenceStatus Status { get; set; }
        public string ReportedByUserName { get; set; } = string.Empty;
        public int? UnitId { get; set; }
        public int CondominiumId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
```

## File: CondoSphere.Core/DTOs/Occurrences/UpdateOccurrenceStatusDto.cs
```csharp
using CondoSphere.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Occurrences
{
    public class UpdateOccurrenceStatusDto
    {
        [Required]
        [EnumDataType(typeof(OccurrenceStatus))]
        public OccurrenceStatus Status { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Condominiums/Assembly.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Condominiums
{
    public class Assembly : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; } = string.Empty;
        public string? MinutesUrl { get; set; }
        public int CondominiumId { get; set; }
        public int CompanyId { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Condominiums/Condominium.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Condominiums
{
    public class Condominium : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int? ManagerId { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Condominiums/Document.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Condominiums
{
    public class Document : IEntity
    {
        /// <summary>
        /// The unique identifier for the document.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The foreign key to the condominium this document belongs to.
        /// </summary>
        public int CondominiumId { get; set; }

        /// <summary>
        /// The foreign key to the company that manages this condominium, for multi-tenancy.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The foreign key to the user who uploaded the document.
        /// </summary>
        public int UploadedByUserId { get; set; }

        /// <summary>
        /// The user-facing title of the document.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// A brief description of the document's content.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The original name of the file that was uploaded.
        /// </summary>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// The path to the file in a physical location (e.g., on disk) or a full URL to its location in blob storage.
        /// </summary>
        public string FilePathOrUrl { get; set; } = string.Empty;

        /// <summary>
        /// The category of the document, used for filtering (e.g., "Minutes", "Regulation", "Budget").
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// The date and time the document was uploaded.
        /// </summary>
        public DateTime UploadDate { get; set; } = DateTime.UtcNow;
    }
}
```

## File: CondoSphere.Core/Entities/Condominiums/Intervention.cs
```csharp
using CondoSphere.Core.Enums;

namespace CondoSphere.Core.Entities.Condominiums
{
    public class Intervention : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public InterventionStatus Status { get; set; }
        public int OccurrenceId { get; set; }
        public int CompanyId { get; set; }
        public int? UnitId { get; set; }
        public int CondominiumId { get; set; }
        public int? AssignedToUserId { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Condominiums/Occurrence.cs
```csharp
using CondoSphere.Core;
using CondoSphere.Core.Enums;

namespace CondoSphere.Core.Entities.Condominiums
{
    public class Occurrence : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReportedDate { get; set; } = DateTime.UtcNow;
        public OccurrenceStatus Status { get; set; }
        public int? UnitId { get; set; }
        public int CondominiumId { get; set; }
        public int CompanyId { get; set; }
        public int ReportedByUserId { get; set; }
        public int? AssignedToUserId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Condominiums/Unit.cs
```csharp
namespace CondoSphere.Core.Entities.Condominiums
{
    /// <summary>
    /// Represents a single unit or fraction within a Condominium,
    /// such as an apartment, office, or storage space.
    /// </summary>
    public class Unit : IEntity
    {
        /// <summary>
        /// The unique primary key for the Unit.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A user-friendly identifier for the unit, such as "Apt 101", "Fraction A", or "Floor 2, Office 3".
        /// This is the name displayed in the UI.
        /// </summary>
        public string Identifier { get; set; } = string.Empty;

        /// <summary>
        /// The foreign key linking this Unit to its parent Condominium.
        /// This is a required field, as a Unit cannot exist without being part of a Condominium.
        /// </summary>
        public int CondominiumId { get; set; }

        /// <summary>
        /// The foreign key to the company that manages this unit's condominium.
        /// This is denormalized from the parent Condominium entity to allow for more
        //  efficient, tenant-scoped queries without requiring a join.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The foreign key to the User who is the official resident of this unit.
        /// Nullable because a unit can be vacant.
        /// </summary>
        public int? ResidentId { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Financials/Expense.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Financials
{
    /// <summary>
    /// Represents a common expense incurred by the condominium (e.g., maintenance, utilities).
    /// </summary>
    public class Expense : IEntity
    {
        /// <summary>
        /// The unique identifier for the expense.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The foreign key to the condominium this expense belongs to.
        /// </summary>
        public int CondominiumId { get; set; }

        /// <summary>
        /// The foreign key to the company, for multi-tenancy.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// A descriptive title for the expense (e.g., "Elevator Maintenance Q3").
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// A more detailed description of the expense.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The total amount of the expense.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The date the expense was incurred.
        /// </summary>
        public DateTime ExpenseDate { get; set; }

        /// <summary>
        /// The name of the supplier or vendor who provided the service/product.
        /// </summary>
        public string? SupplierName { get; set; }

        /// <summary>
        /// The reference number from the supplier's invoice.
        /// </summary>
        public string? InvoiceNumber { get; set; }

        /// <summary>
        /// The category of the expense for reporting (e.g., "Maintenance", "Utilities", "Cleaning").
        /// </summary>
        public string Category { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/Entities/Financials/QuotaPayment.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Financials
{
    public class QuotaPayment : IEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string? TransactionReference { get; set; }
        public int UnitQuotaId { get; set; }
        public int UnitId { get; set; }
        public int CompanyId { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Financials/Receipt.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Financials
{
    public class Receipt : IEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public int QuotaPaymentId { get; set; }
        public string Details { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int CondominiumId { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Financials/UnitQuota.cs
```csharp
using CondoSphere.Core;
using CondoSphere.Core.Enums;

namespace CondoSphere.Core.Entities.Financials
{
    /// <summary>
    /// Represents a single quota (bill or charge) issued to a condominium unit.
    /// This is the core record for what a resident owes.
    /// </summary>
    public class UnitQuota : IEntity
    {
        /// <summary>
        /// The unique identifier for the quota.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The foreign key to the specific unit this quota is for.
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// The foreign key to the condominium, denormalized for easier querying.
        /// </summary>
        public int CondominiumId { get; set; }

        /// <summary>
        /// The foreign key to the company, for multi-tenancy.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// A description of the quota (e.g., "Monthly Fee - August 2024").
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The total amount that is due for this quota.
        /// </summary>
        public decimal AmountDue { get; set; }

        /// <summary>
        /// The date by which this quota should be paid.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// The amount that has been paid towards this quota so far.
        /// </summary>
        public decimal AmountPaid { get; set; }

        /// <summary>
        /// The date the quota was fully paid. Null if not yet paid.
        /// </summary>
        public DateTime? PaymentDate { get; set; }

        /// <summary>
        /// The current status of the quota (e.g., "Pending", "Paid", "PartiallyPaid", "Overdue").
        /// </summary>
        public UnitQuotaStatus Status { get; set; }

        /// <summary>
        /// A payment reference number, if applicable (e.g., Multibanco reference).
        /// </summary>
        public string? ReferenceNumber { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Users/Company.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Users
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? VatNumber { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
```

## File: CondoSphere.Core/Entities/Users/Notification.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Users
{
    public class Notification : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime SentDate { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; }
        public DateTime? ReadDate { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Users/User.cs
```csharp
using CondoSphere.Core;
using Microsoft.AspNetCore.Identity;

namespace CondoSphere.Core.Entities.Users
{
    /// <summary>
    /// Represents a user in the system. Extends the default ASP.NET Core IdentityUser
    /// to use an integer as the primary key and adds custom properties.
    /// The 'Id' from IdentityUser<int> satisfies the IEntity interface contract.
    /// </summary>
    public class User : IdentityUser<int>, IEntity
    {
     
        public int? CompanyId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; } = true;
        public string? ProfilePictureUrl { get; set; }
    }
}
```

## File: CondoSphere.Core/Enums/InterventionStatus.cs
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.Enums
{
    /// <summary>
    /// Represents the possible statuses for a maintenance intervention.
    /// </summary>
    public enum InterventionStatus
    {
        /// <summary>
        /// The intervention has been planned but not yet started.
        /// </summary>
        Scheduled = 1,

        /// <summary>
        /// The intervention is currently in progress.
        /// </summary>
        InProgress = 2,

        /// <summary>
        /// The intervention work has been completed.
        /// </summary>
        Completed = 3,

        /// <summary>
        /// The intervention has been cancelled.
        /// </summary>
        Cancelled = 4
    }
}
```

## File: CondoSphere.Core/Enums/OccurrenceStatus.cs
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.Enums
{
    public enum OccurrenceStatus
    {
        /// <summary>
        /// The occurrence has been reported but not yet acted upon.
        /// </summary>
        Open = 1,

        /// <summary>
        /// The occurrence is currently being worked on.
        /// </summary>
        InProgress = 2,

        /// <summary>
        /// The occurrence is temporarily on hold.
        /// </summary>
        OnHold = 3,

        /// <summary>
        /// The issue has been resolved but is pending final confirmation.
        /// </summary>
        Resolved = 4,

        /// <summary>
        /// The occurrence has been fully resolved and closed.
        /// </summary>
        Closed = 5
    }
}
```

## File: CondoSphere.Core/Enums/SystemRole.cs
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.Enums
{
    /// <summary>
    /// Represents the core user roles within the system.
    /// The values should correspond to the IDs in the Roles database table.
    /// </summary>
    public enum SystemRole
    {
        CompanyAdmin = 1,
        CondoManager = 2,
        CondoResident = 3,
        Employee = 4,
        PlatformSuperAdmin = 5
    }
}
```

## File: CondoSphere.Core/Enums/UnitQuotaStatus.cs
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.Enums
{
    /// <summary>
    /// Represents the possible statuses for a unit's quota (bill).
    /// </summary>
    public enum UnitQuotaStatus
    {
        /// <summary>
        /// The quota has been issued but not yet paid.
        /// </summary>
        Pending = 1,

        /// <summary>
        /// The quota has been paid in full.
        /// </summary>
        Paid = 2,

        /// <summary>
        /// The quota has been partially paid.
        /// </summary>
        PartiallyPaid = 3,

        /// <summary>
        /// The quota's due date has passed, and it remains unpaid.
        /// </summary>
        Overdue = 4,

        /// <summary>
        /// The quota has been cancelled or voided.
        /// </summary>
        Cancelled = 5
    }
}
```

## File: CondoSphere.Core/IEntity.cs
```csharp
namespace CondoSphere.Core
{
    public interface IEntity
    {
        public int Id { get; set; }
    }
}
```

## File: CondoSphere.Core/Response.cs
```csharp
using System.Collections.Generic;

namespace CondoSphere.Core
{
    // Non-generic version for service methods that don't return data (e.g., void methods)
    public class Response : Response<object>
    {
        // Static factory methods for non-generic success/fail responses
        public new static Response Success()
        {
            return new Response { Succeeded = true };
        }

        public new static Response Fail(string error)
        {
            return new Response { Succeeded = false, Errors = new List<string> { error } };
        }

        public new static Response Fail(IEnumerable<string> errors)
        {
            return new Response { Succeeded = false, Errors = new List<string>(errors) };
        }
    }

    // Generic version for service methods that return data
    public class Response<T>
    {
        public bool Succeeded { get; protected set; }
        public T? Data { get; protected set; }
        public List<string>? Errors { get; protected set; }

        // Factory method for a successful response with data
        public static Response<T> Success(T data)
        {
            return new Response<T> { Succeeded = true, Data = data };
        }

        // Factory method for a failed response
        public static Response<T> Fail(string error)
        {
            return new Response<T> { Succeeded = false, Errors = new List<string> { error } };
        }

        public static Response<T> Fail(IEnumerable<string> errors)
        {
            return new Response<T> { Succeeded = false, Errors = new List<string>(errors) };
        }
    }
}
```

## File: CondoSphere.Core/RoleConstants.cs
```csharp
namespace CondoSphere.Core
{
    /// <summary>
    /// Provides constant string values for system roles to avoid magic strings in code.
    /// </summary>
    public static class RoleConstants
    {
        public const string CompanyAdmin = "CompanyAdmin";
        public const string CondoManager = "CondoManager";
        public const string CondoResident = "CondoResident";
        public const string Employee = "Employee";
        public const string PlatformSuperAdmin = "PlatformSuperAdmin";
    }
}
```

## File: CondoSphere.Core/ValidationAttributes/DateNotInPastAttribute.cs
```csharp
using System;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.ValidationAttributes
{
    public class DateNotInPastAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime >= DateTime.Now.AddMinutes(-5);
            }
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return "The selected date and time cannot be in the past.";
        }
    }
}
```

## File: CondoSphere.Infrastructure/Authorization/CanAccessOccurrenceHandler.cs
```csharp
using CondoSphere.Application.Authorization;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CoreOccurrence = CondoSphere.Core.Entities.Condominiums.Occurrence;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Infrastructure.Authorization
{
    public class CanAccessOccurrenceHandler : AuthorizationHandler<CanAccessOccurrenceRequirement, CoreOccurrence>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<CoreUser> _userManager;

        public CanAccessOccurrenceHandler(ICurrentUserService currentUserService, UserManager<CoreUser> userManager)
        {
            _currentUserService = currentUserService;
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(
                                 AuthorizationHandlerContext context,
                                 CanAccessOccurrenceRequirement requirement,
                                 CoreOccurrence resource)
        {
            var userId = _currentUserService.UserId;
            if (userId == null)
            {
                context.Fail();
                return;
            }

            // Rule 1: Allow if the user is the one who reported it.
            if (resource.ReportedByUserId == userId.Value)
            {
                context.Succeed(requirement);
                return;
            }

            // Rule2: Allow if the user is the employee assigned to the occurrence
            if (resource.AssignedToUserId.HasValue && resource.AssignedToUserId.Value == userId.Value)
            {
                context.Succeed(requirement);
                return;
            }

            // Rule 3: Allow if the user is a CompanyAdmin or CondoManager for that company.
            var user = await _userManager.FindByIdAsync(userId.Value.ToString());
            if (user?.CompanyId == resource.CompanyId)
            {
                if (context.User.IsInRole(RoleConstants.CompanyAdmin) || context.User.IsInRole(RoleConstants.CondoManager))
                {
                    context.Succeed(requirement);
                    return;
                }
            }

            context.Fail();
        }
    }
}
```

## File: CondoSphere.Infrastructure/Authorization/CanManageInterventionHandler.cs
```csharp
using CondoSphere.Application.Authorization;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core;
using Microsoft.AspNetCore.Authorization;
using CoreIntervention = CondoSphere.Core.Entities.Condominiums.Intervention;

namespace CondoSphere.Infrastructure.Authorization
{
    public class CanManageInterventionHandler : AuthorizationHandler<CanManageInterventionRequirement, CoreIntervention>
    {
        private readonly ICurrentUserService _currentUserService;

        public CanManageInterventionHandler(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            CanManageInterventionRequirement requirement,
            CoreIntervention resource)
        {
            var userId = _currentUserService.UserId;
            if (userId == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            // Rule 1: Allow if the user is the employee assigned to the intervention.
            if (resource.AssignedToUserId.HasValue && resource.AssignedToUserId.Value == userId.Value)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            // Rule 2: Allow if the user is a CompanyAdmin or CondoManager.
            // (The check for company is implicit in how we fetch the resource).
            if (context.User.IsInRole(RoleConstants.CompanyAdmin) || context.User.IsInRole(RoleConstants.CondoManager))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            context.Fail();
            return Task.CompletedTask;
        }
    }
}
```

## File: CondoSphere.Infrastructure/Authorization/IsCondoManagerHandler.cs
```csharp
using CondoSphere.Application.Authorization;
using CondoSphere.Core;
using CondoSphere.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CondoSphere.Infrastructure.Authorization
{
    public class IsCondoManagerHandler : AuthorizationHandler<IsCondoManagerRequirement>
    {
        private readonly CondominiumDbContext _condoContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IsCondoManagerHandler(CondominiumDbContext condoContext, IHttpContextAccessor httpContextAccessor)
        {
            _condoContext = condoContext;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            IsCondoManagerRequirement requirement)
        {
            // First, check for the override role. A CompanyAdmin can manage everything.
            if (context.User.IsInRole(RoleConstants.CompanyAdmin))
            {
                context.Succeed(requirement);
                return;
            }

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                context.Fail();
                return;
            }

            var userIdClaim = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdClaim, out var userId))
            {
                context.Fail();
                return;
            }

            var condominiumIdRouteValue = httpContext.GetRouteValue("condominiumId")?.ToString();
            if (!int.TryParse(condominiumIdRouteValue, out var condominiumId))
            {
                condominiumIdRouteValue = httpContext.GetRouteValue("id")?.ToString();
                if (!int.TryParse(condominiumIdRouteValue, out condominiumId))
                {
                    context.Fail();
                    return;
                }
            }

            // Check the database to see if this user is the manager of this condominium.
            // We do NOT use IgnoreQueryFilters() here. This is intentional.
            // We want this authorization check to respect any global filters, such as a
            // potential future soft-delete "IsActive" flag on condominiums.
            bool isManagerOfCondo = await _condoContext.Condominiums
                .AnyAsync(c => c.Id == condominiumId && c.ManagerId == userId);

            if (isManagerOfCondo)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}
```

## File: CondoSphere.Infrastructure/Data/CondominiumDbContext.cs
```csharp
using CondoSphere.Core.Entities.Condominiums;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Data
{
    public class CondominiumDbContext : DbContext
    {
        // DbSet for each entity that belongs in this database
        public DbSet<Condominium> Condominiums { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Occurrence> Occurrences { get; set; }
        public DbSet<Intervention> Interventions { get; set; }
        public DbSet<Assembly> Assemblies { get; set; }
        // TODO: Add DbSets for the virtual assembly features later

        public CondominiumDbContext(DbContextOptions<CondominiumDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Here we can add configurations, like composite keys
            // For example, ensuring a Unit identifier is unique within a Condominium
            modelBuilder.Entity<Unit>()
                .HasIndex(u => new { u.CondominiumId, u.Identifier })
                .IsUnique();
        }
    }
}
```

## File: CondoSphere.Infrastructure/Data/SeedDb.cs
```csharp
using CondoSphere.Core;
using CondoSphere.Core.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace CondoSphere.Infrastructure.Data
{
    /// <summary>
    /// Responsible for seeding initial data into the database.
    /// </summary>
    public class SeedDb
    {
        private readonly UserManagementDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public SeedDb(UserManagementDbContext context, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
        }

        private async Task CheckRolesAsync()
        {
            // Use the constant for the check
            if (!await _roleManager.RoleExistsAsync(RoleConstants.CompanyAdmin))
            {
                // Use the constants for creation
                await _roleManager.CreateAsync(new IdentityRole<int>(RoleConstants.CompanyAdmin));
                await _roleManager.CreateAsync(new IdentityRole<int>(RoleConstants.CondoManager));
                await _roleManager.CreateAsync(new IdentityRole<int>(RoleConstants.CondoResident));
                await _roleManager.CreateAsync(new IdentityRole<int>(RoleConstants.Employee));
                await _roleManager.CreateAsync(new IdentityRole<int>(RoleConstants.PlatformSuperAdmin));
            }
        }
    }
}
```

## File: CondoSphere.Infrastructure/Data/UserManagementDbContext.cs
```csharp
using CondoSphere.Core.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Data
{
    /// <summary>
    /// Represents the database context for the User Management database.
    /// Inherits from IdentityDbContext to include tables for ASP.NET Core Identity.
    /// </summary>
    public class UserManagementDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        // DbSet properties tell EF Core which of our entities should become tables.

        /// <summary>
        /// Represents the 'Companies' table.
        /// </summary>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Represents the 'Notifications' table.
        /// </summary>
        public DbSet<Notification> Notifications { get; set; }

        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().HasQueryFilter(u => u.IsActive);
            builder.Entity<Company>().HasQueryFilter(c => c.IsActive);
        }
    }
}
```

## File: CondoSphere.Infrastructure/Repositories/CompanyRepository.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Users;
using CondoSphere.Infrastructure.Data;

namespace CondoSphere.Infrastructure.Repositories
{
    /// <summary>
    /// Implements the ICompanyRepository using Entity Framework Core.
    /// This repository modifies the change tracker but does not save to the database.
    /// </summary>
    public class CompanyRepository : ICompanyRepository
    {
        private readonly UserManagementDbContext _context;

        public CompanyRepository(UserManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Company company)
        {
            // This adds the entity to EF Core's change tracker.
            await _context.Companies.AddAsync(company);
        }

        public void Remove(Company company)
        {
            // This marks the entity for deletion in EF Core's change tracker.
            _context.Companies.Remove(company);
        }
    }
}
```

## File: CondoSphere.Infrastructure/Repositories/CondominiumRepository.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Condominiums;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    /// <summary>
    /// Implements the ICondominiumRepository using Entity Framework Core.
    /// This repository modifies the change tracker but does not save to the database.
    /// </summary>
    public class CondominiumRepository : ICondominiumRepository
    {
        private readonly CondominiumDbContext _context;

        public CondominiumRepository(CondominiumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Condominium condominium)
        {
            await _context.Condominiums.AddAsync(condominium);
        }

        public async Task<IEnumerable<Condominium>> GetAllAsync(int companyId, int pageNumber, int pageSize)
        {
            var query = _context.Condominiums
                .Where(c => c.CompanyId == companyId);

            var pagedQuery = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await pagedQuery.AsNoTracking().ToListAsync();
        }

        public async Task<Condominium?> GetByIdAsync(int id, int companyId)
        {
            return await _context.Condominiums
                .FirstOrDefaultAsync(c => c.Id == id && c.CompanyId == companyId);
        }

        public void Remove(Condominium condominium)
        {
            _context.Condominiums.Remove(condominium);
        }

        public void Update(Condominium condominium)
        {
            // This marks the entity for update in EF Core's change tracker.
            _context.Entry(condominium).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Condominium>> GetByManagerIdAsync(int managerId)
        {
            return await _context.Condominiums
                .Where(c => c.ManagerId == managerId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
```

## File: CondoSphere.Infrastructure/Repositories/InterventionRepository.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Condominiums;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class InterventionRepository : IInterventionRepository
    {
        private readonly CondominiumDbContext _context;

        public InterventionRepository(CondominiumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Intervention intervention)
        {
            await _context.Interventions.AddAsync(intervention);
        }

        public async Task<IEnumerable<Intervention>> GetByOccurrenceIdAsync(int occurrenceId)
        {
            return await _context.Interventions
                .Where(i => i.OccurrenceId == occurrenceId)
                .OrderBy(i => i.StartDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Intervention>> GetByAssignedUserIdAsync(int employeeId)
        {
            return await _context.Interventions
                .Where(i => i.AssignedToUserId == employeeId)
                .OrderBy(i => i.StartDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Intervention?> GetByIdAsync(int interventionId)
        {
            return await _context.Interventions.FindAsync(interventionId);
        }

        public void Update(Intervention intervention)
        {
            _context.Entry(intervention).State = EntityState.Modified;
        }
    }
}
```

## File: CondoSphere.Infrastructure/Repositories/OccurrenceRepository.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Condominiums;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class OccurrenceRepository : IOccurrenceRepository
    {
        private readonly CondominiumDbContext _context;

        public OccurrenceRepository(CondominiumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Occurrence occurrence)
        {
            // This adds the entity to EF Core's change tracker.
            await _context.Occurrences.AddAsync(occurrence);
        }

        public async Task<IEnumerable<Occurrence>> GetAllForCondominiumAsync(int condominiumId)
        {
            return await _context.Occurrences
                .Where(o => o.CondominiumId == condominiumId)
                .OrderByDescending(o => o.ReportedDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Occurrence?> GetByIdAsync(int occurrenceId)
        {
            return await _context.Occurrences.FindAsync(occurrenceId);
        }

        public async Task<IEnumerable<Occurrence>> GetAllForResidentAsync(int residentUserId)
        {
            return await _context.Occurrences
                .Where(o => o.ReportedByUserId == residentUserId)
                .OrderByDescending(o => o.ReportedDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public void Update(Occurrence occurrence)
        {
            _context.Entry(occurrence).State = EntityState.Modified;
        }
    }
}
```

## File: CondoSphere.Infrastructure/Repositories/UnitOfWork.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Infrastructure.Data;

namespace CondoSphere.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManagementDbContext _userContext;
        private readonly CondominiumDbContext _condoContext;

        // Implement all properties from the interface
        public ICompanyRepository Companies { get; private set; }
        public IUserRepository Users { get; private set; }
        public ICondominiumRepository Condominiums { get; private set; }
        public IUnitRepository Units { get; private set; }
        public IOccurrenceRepository Occurrences { get; private set; }
        public IInterventionRepository Interventions { get; private set; }

        public UnitOfWork(UserManagementDbContext userContext, CondominiumDbContext condoContext)
        {
            _userContext = userContext;
            _condoContext = condoContext;

            // Instantiate all repositories with their respective DbContexts
            Companies = new CompanyRepository(_userContext);
            Users = new UserRepository(_userContext);
            Condominiums = new CondominiumRepository(_condoContext);
            Units = new UnitRepository(_condoContext);
            Occurrences = new OccurrenceRepository(_condoContext);
            Interventions = new InterventionRepository(_condoContext);
        }

        public async Task<int> CompleteAsync()
        {
            // Save changes for both contexts. The sum of records affected is returned.
            var userDbResult = await _userContext.SaveChangesAsync();
            var condoDbResult = await _condoContext.SaveChangesAsync();
            return userDbResult + condoDbResult;
        }

        public async ValueTask DisposeAsync()
        {
            await _userContext.DisposeAsync();
            await _condoContext.DisposeAsync();
        }


    }
}
```

## File: CondoSphere.Infrastructure/Repositories/UnitRepository.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Condominiums;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondoSphere.Infrastructure.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly CondominiumDbContext _context;

        public UnitRepository(CondominiumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Unit unit)
        {
            await _context.Units.AddAsync(unit);
        }

        public void Update(Unit unit)
        {
            _context.Entry(unit).State = EntityState.Modified;
        }

        public void Remove(Unit unit)
        {
            _context.Units.Remove(unit);
        }

        public async Task<IEnumerable<Unit>> GetAllAsync(int condominiumId)
        {
            return await _context.Units
                .Where(u => u.CondominiumId == condominiumId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Unit?> GetByIdAsync(int unitId)
        {
            return await _context.Units.FindAsync(unitId);
        }

        public async Task<IEnumerable<int>> GetOccupiedUnitResidentIdsAsync(int companyId)
        {
            return await _context.Units
                .Where(u => u.CompanyId == companyId && u.ResidentId.HasValue)
                .Select(u => u.ResidentId.Value)
                .Distinct()
                .ToListAsync();
        }

        public async Task<Unit?> GetUnitByResidentIdAsync(int residentId)
        {
            return await _context.Units
                .FirstOrDefaultAsync(u => u.ResidentId == residentId);
        }
    }
}
```

## File: CondoSphere.Infrastructure/Repositories/UserRepository.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondoSphere.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagementDbContext _context;

        public UserRepository(UserManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserListDto>> GetCompanyUsersWithRolesAsync(int companyId)
        {
            // This query is correct and should remain.
            var usersWithRoles = await _context.Users
                .IgnoreQueryFilters()
                .Where(u => u.CompanyId == companyId)
                .Select(u => new UserListDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    IsActive = u.IsActive,
                    Role = (from userRole in _context.UserRoles
                            join role in _context.Roles on userRole.RoleId equals role.Id
                            where userRole.UserId == u.Id
                            select role.Name).FirstOrDefault() ?? "No Role"
                })
                .AsNoTracking()
                .ToListAsync();

            return usersWithRoles;
        }

        public async Task<IEnumerable<UserListDto>> GetUsersInRoleAsync(string roleName, int companyId)
        {
            // This query is also correct and should remain.
            var usersInRole = await _context.Users
                .Where(u => u.CompanyId == companyId && _context.UserRoles.Any(ur => ur.UserId == u.Id && _context.Roles.Any(r => r.Id == ur.RoleId && r.Name == roleName)))
                .Select(u => new UserListDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    IsActive = u.IsActive,
                    Role = roleName
                })
                .AsNoTracking()
                .ToListAsync();

            return usersInRole;
        }
    }
}
```

## File: CondoSphere.Infrastructure/Services/CurrentUserService.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CondoSphere.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CondominiumDbContext _condoContext;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, CondominiumDbContext condoContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _condoContext = condoContext;
        }

        public int? UserId => GetClaimValue<int>(ClaimTypes.NameIdentifier);

        public int? CompanyId => GetClaimValue<int>("companyId");

        public string? UserEmail => GetClaimValue<string>(ClaimTypes.Email);

        public bool IsInRole(string roleName)
        {
            return _httpContextAccessor.HttpContext?.User.IsInRole(roleName) ?? false;
        }

        private T? GetClaimValue<T>(string claimType)
        {
            var claimValue = _httpContextAccessor.HttpContext?.User?.FindFirstValue(claimType);
            if (string.IsNullOrEmpty(claimValue))
            {
                return default;
            }
            return (T)Convert.ChangeType(claimValue, typeof(T));
        }

        public async Task<(bool IsAuthorized, int? CompanyId)> CanManageCondominium(int condominiumId)
        {
            var userId = this.UserId; // Get user ID from the existing property
            if (userId == null) return (false, null);

            // One single, efficient database call to check everything.
            var condo = await _condoContext.Condominiums
                                .AsNoTracking()
                                .FirstOrDefaultAsync(c => c.Id == condominiumId && c.ManagerId == userId);

            if (condo != null)
            {
                // If found, user is authorized, and we return the condo's CompanyId.
                return (true, condo.CompanyId);
            }

            // If not found, user is not authorized.
            return (false, null);
        }
    }
}
```

## File: CondoSphere.Infrastructure/Services/MailService.cs
```csharp
using CondoSphere.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace CondoSphere.Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string toEmail, string subject, string content)
        {
            // Read all settings from configuration (appsettings + user secrets)
            var from = _configuration["MailSettings:From"];
            var smtp = _configuration["MailSettings:Smtp"];
            var port = int.Parse(_configuration["MailSettings:Port"]);
            var password = _configuration["MailSettings:Password"];

            var message = new MailMessage
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = content,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(toEmail));

            // Configure the SmtpClient for Gmail
            var client = new SmtpClient
            {
                Host = smtp,
                Port = port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            return client.SendMailAsync(message);
        }
    }
}
```

## File: CondoSphere.Web/appsettings.Development.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## File: CondoSphere.Web/appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## File: CondoSphere.Web/Controllers/AccountController.cs
```csharp
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
            if (User.IsInRole(RoleConstants.Employee))
            {
                return RedirectToAction("Index", "Employee");
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
    }
}
```

## File: CondoSphere.Web/Controllers/AdministrationController.cs
```csharp
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CondoSphere.Web.Controllers
{
    [Authorize(Roles = RoleConstants.CompanyAdmin)]
    [Route("administration")]
    public class AdministrationController : Controller
    {
        private readonly ApiClient _apiClient;

        public AdministrationController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var users = await _apiClient.GetUsersAsync();
            var condominiums = await _apiClient.GetCondominiumsAsync();

            var viewModel = new ManagementDashboardViewModel
            {
                Users = users ?? new List<UserListDto>(),
                Condominiums = condominiums ?? new List<CondominiumDto>()
            };

            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            int.TryParse(userIdClaim, out var currentUserId);
            ViewData["CurrentUserId"] = currentUserId;

            return View(viewModel);
        }

        [HttpGet("register-manager")]
        public IActionResult RegisterManager()
        {
            return View();
        }

        [HttpPost("register-manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterManager(RegisterManagerDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await _apiClient.RegisterManagerAsync(model);

            if (success)
            {
                TempData["SuccessMessage"] = "Manager registration initiated. They will receive an email to set their password.";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Failed to register manager. The email may already be in use.");
            return View(model);
        }

        [HttpGet("create-condominium")]
        public IActionResult CreateCondominium()
        {
            return View();
        }

        [HttpPost("create-condominium")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCondominium(CreateUpdateCondominiumDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await _apiClient.CreateCondominiumAsync(model);

            if (success)
            {
                TempData["SuccessMessage"] = "Condominium created successfully!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the condominium. Please try again.");
            return View(model);
        }

        [HttpGet("condominiums/{condominiumId}/assign-manager")]
        public async Task<IActionResult> AssignManager(int condominiumId)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            if (condo == null)
            {
                return NotFound();
            }

            var managers = await _apiClient.GetAvailableManagersAsync();

            ViewData["Condominium"] = condo;
            ViewData["AvailableManagers"] = managers.Select(m => new SelectListItem
            {
                Text = $"{m.FirstName} {m.LastName} ({m.Email})",
                Value = m.Id.ToString()
            });

            return View(new AssignManagerViewModel());
        }

        [HttpPost("condominiums/{condominiumId}/assign-manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignManager(int condominiumId, AssignManagerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await RepopulateAssignManagerViewDataAsync(condominiumId);
                return View(model);
            }

            var dto = new AssignManagerDto { ManagerId = model.SelectedManagerId };
            var success = await _apiClient.AssignManagerAsync(condominiumId, dto);

            if (success)
            {
                TempData["SuccessMessage"] = "Manager assigned successfully!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while assigning the manager. Please verify the manager is valid and try again.");

            await RepopulateAssignManagerViewDataAsync(condominiumId);
            return View(model);
        }

        private async Task RepopulateAssignManagerViewDataAsync(int condominiumId)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            var managers = await _apiClient.GetAvailableManagersAsync();
            ViewData["Condominium"] = condo;
            ViewData["AvailableManagers"] = managers.Select(m => new SelectListItem
            {
                Text = $"{m.FirstName} {m.LastName} ({m.Email})",
                Value = m.Id.ToString()
            });
        }

        [HttpPost("users/{userId}/deactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateUser(int userId)
        {
            var success = await _apiClient.DeactivateUserAsync(userId);
            if (success)
            {
                TempData["SuccessMessage"] = "User successfully deactivated.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to deactivate user.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("users/{userId}/activate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActivateUser(int userId)
        {
            var success = await _apiClient.ActivateUserAsync(userId);
            if (success)
            {
                TempData["SuccessMessage"] = "User successfully activated.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to activate user.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("register-employee")]
        public IActionResult RegisterEmployee()
        {
            return View();
        }

        [HttpPost("register-employee")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterEmployee(RegisterManagerDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await _apiClient.RegisterEmployeeAsync(model);

            if (success)
            {
                TempData["SuccessMessage"] = "Employee registration initiated. They will receive an email to set their password.";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Failed to register employee. The email may already be in use.");
            return View(model);
        }
    }
}
```

## File: CondoSphere.Web/Controllers/CondoManagementController.cs
```csharp
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Core.Enums;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CondoSphere.Web.Controllers
{
    [Authorize(Roles = RoleConstants.CondoManager)]
    [Route("condo-management")]
    public class CondoManagementController : Controller
    {
        private readonly ApiClient _apiClient;

        public CondoManagementController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var condominiums = await _apiClient.GetMyManagedCondominiumsAsync();
            return View(condominiums);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(id);
            var units = await _apiClient.GetUnitsForCondominiumAsync(id);
            var users = await _apiClient.GetUsersAsync();
            var userLookup = users.ToDictionary(u => u.Id, u => $"{u.FirstName} {u.LastName}");
            var occurrences = await _apiClient.GetOccurrencesForCondominiumAsync(id);

            var unitViewModels = units.Select(unit => new UnitDetailViewModel
            {
                Id = unit.Id,
                Identifier = unit.Identifier,
                ResidentId = unit.ResidentId,
                ResidentName = unit.ResidentId.HasValue && userLookup.ContainsKey(unit.ResidentId.Value)
                    ? userLookup[unit.ResidentId.Value]
                    : null
            });

            var viewModel = new CondominiumDetailsViewModel
            {
                Condominium = condo,
                Units = unitViewModels,
                Occurrences = occurrences
            };

            return View(viewModel);
        }

        [HttpGet("units/{unitId}/register-resident")]
        public IActionResult RegisterResident(int unitId, int condominiumId)
        {
            var model = new RegisterResidentViewModel
            {
                UnitId = unitId,
                CondominiumId = condominiumId
            };
            return View(model);
        }

        [HttpPost("units/{unitId}/register-resident")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterResident(RegisterResidentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Create the DTO to send to the API from the ViewModel
            var dto = new RegisterResidentDto
            {
                UnitId = model.UnitId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            // ===== CORRECTED LOGIC HERE =====
            // The ApiClient method returns a simple boolean, not a tuple.
            var success = await _apiClient.RegisterResidentAsync(model.CondominiumId, dto);

            if (success)
            {
                TempData["SuccessMessage"] = "Resident registered successfully! A welcome email has been sent.";
                return RedirectToAction(nameof(Details), new { id = model.CondominiumId });
            }

            // Use a generic error message since the current ApiClient doesn't return a specific one.
            ModelState.AddModelError(string.Empty, "Failed to register resident. The unit may be occupied or the email may be in use.");
            return View(model);
        }

        [HttpGet("{condominiumId}/units/create")]
        public IActionResult CreateUnit(int condominiumId)
        {
            ViewData["CondominiumId"] = condominiumId;
            return View();
        }

        [HttpPost("{condominiumId}/units/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUnit(int condominiumId, CreateUpdateUnitDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["CondominiumId"] = condominiumId;
                return View(dto);
            }

            var success = await _apiClient.CreateUnitAsync(condominiumId, dto);
            if (success)
            {
                TempData["SuccessMessage"] = $"Unit '{dto.Identifier}' was created successfully!";
                return RedirectToAction(nameof(Details), new { id = condominiumId });
            }

            ModelState.AddModelError(string.Empty, "Failed to create the unit. Please try again.");
            ViewData["CondominiumId"] = condominiumId;
            return View(dto);
        }

        [HttpPost("{condominiumId}/units/{unitId}/unassign")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnassignResident(int condominiumId, int unitId)
        {
            var success = await _apiClient.UnassignResidentAsync(condominiumId, unitId);

            if (success)
            {
                TempData["SuccessMessage"] = "Resident has been unassigned and the unit is now vacant.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to unassign resident."; // We'll need to display this in the layout
            }

            return RedirectToAction(nameof(Details), new { id = condominiumId });
        }

        [HttpGet("units/{unitId}/assign-resident")]
        public async Task<IActionResult> AssignResident(int unitId, int condominiumId)
        {
            var availableResidents = await _apiClient.GetAvailableResidentsAsync();

            var viewModel = new AssignResidentViewModel
            {
                UnitId = unitId,
                CondominiumId = condominiumId,
                AvailableResidents = availableResidents.Select(r => new SelectListItem
                {
                    Text = $"{r.FirstName} {r.LastName} ({r.Email})",
                    Value = r.Id.ToString()
                })
            };

            return View(viewModel);
        }

        [HttpPost("units/{unitId}/assign-resident")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignResident(AssignResidentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var availableResidents = await _apiClient.GetAvailableResidentsAsync();
                model.AvailableResidents = availableResidents.Select(r => new SelectListItem
                {
                    Text = $"{r.FirstName} {r.LastName} ({r.Email})",
                    Value = r.Id.ToString()
                });
                return View(model);
            }

            var dto = new AssignResidentDto { ResidentId = model.SelectedResidentId };
            var success = await _apiClient.AssignResidentAsync(model.CondominiumId, model.UnitId, dto);

            if (success)
            {
                TempData["SuccessMessage"] = "Resident assigned successfully!";
                return RedirectToAction(nameof(Details), new { id = model.CondominiumId });
            }

            ModelState.AddModelError(string.Empty, "Failed to assign resident. Please ensure the resident is valid and the unit is vacant.");

            var residents = await _apiClient.GetAvailableResidentsAsync();
            model.AvailableResidents = residents.Select(r => new SelectListItem
            {
                Text = $"{r.FirstName} {r.LastName} ({r.Email})",
                Value = r.Id.ToString()
            });
            return View(model);
        }

        [HttpGet("{condominiumId}/occurrences/{occurrenceId}")]
        public async Task<IActionResult> OccurrenceDetails(int condominiumId, int occurrenceId)
        {
            var occurrenceTask = _apiClient.GetOccurrenceDetailsAsync(occurrenceId);
            var interventionsTask = _apiClient.GetInterventionsForOccurrenceAsync(occurrenceId);
            var employeesTask = _apiClient.GetAvailableEmployeesAsync();

            await Task.WhenAll(occurrenceTask, interventionsTask, employeesTask);

            var occurrence = await occurrenceTask;
            var interventions = await interventionsTask;
            var employees = await employeesTask;

            if (occurrence == null)
            {
                return NotFound();
            }
            if (occurrence.CondominiumId != condominiumId)
            {
                return Forbid();
            }

            ViewData["AvailableEmployees"] = new SelectList(employees, "Id", "FullName");

            var viewModel = new OccurrenceDetailsViewModel
            {
                Occurrence = occurrence,
                Interventions = interventions,
                NewIntervention = new CreateInterventionDto
                {
                    OccurrenceId = occurrenceId,
                    StartDate = DateTime.Now
                }
            };

            return View(viewModel);
        }

        [HttpPost("{condominiumId}/occurrences/{occurrenceId}/update-status")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateOccurrenceStatus(int condominiumId, int occurrenceId, UpdateOccurrenceStatusDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid status selected.";
                return RedirectToAction("OccurrenceDetails", new { condominiumId, occurrenceId });
            }

            var success = await _apiClient.UpdateOccurrenceStatusAsync(occurrenceId, dto);
            if (success)
            {
                TempData["SuccessMessage"] = "Occurrence status has been updated.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update status.";
            }

            return RedirectToAction("OccurrenceDetails", new { condominiumId, occurrenceId });
        }

        [HttpPost("{condominiumId}/occurrences/{occurrenceId}/create-intervention")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateIntervention(int condominiumId, int occurrenceId, [Bind(Prefix = "NewIntervention")] CreateInterventionDto interventionDto)
        {
            if (!ModelState.IsValid)
            {
                var occurrenceTask = _apiClient.GetOccurrenceDetailsAsync(occurrenceId);
                var interventionsTask = _apiClient.GetInterventionsForOccurrenceAsync(occurrenceId);
                var employeesTask = _apiClient.GetAvailableEmployeesAsync();
                await Task.WhenAll(occurrenceTask, interventionsTask, employeesTask);

                var occurrence = await occurrenceTask;
                var interventions = await interventionsTask;
                var employees = await employeesTask;

                ViewData["AvailableEmployees"] = new SelectList(employees, "Id", "FullName");

                var viewModel = new OccurrenceDetailsViewModel
                {
                    Occurrence = occurrence,
                    Interventions = interventions,
                    NewIntervention = interventionDto
                };
                return View("OccurrenceDetails", viewModel);
            }
            var result = await _apiClient.CreateInterventionAsync(interventionDto);
            if (result != null)
            {
                TempData["SuccessMessage"] = "Intervention successfully created.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to create intervention.";
            }

            return RedirectToAction("OccurrenceDetails", new { condominiumId, occurrenceId });
        }

        [HttpPost("{condominiumId}/occurrences/{occurrenceId}/update-intervention-status")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInterventionStatus(int condominiumId, int occurrenceId, int interventionId, InterventionStatus status)
        {
            var dto = new UpdateInterventionStatusDto { Status = status };

            var success = await _apiClient.UpdateInterventionStatusAsync(interventionId, dto);

            if (success)
            {
                TempData["SuccessMessage"] = "Intervention status has been updated.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update intervention status.";
            }

            return RedirectToAction("OccurrenceDetails", new { condominiumId, occurrenceId });
        }
    }
}
```

## File: CondoSphere.Web/Controllers/EmployeeController.cs
```csharp
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.Web.Controllers
{
    [Authorize(Roles = RoleConstants.Employee)]
    [Route("employee")]
    public class EmployeeController : Controller
    {
        private readonly ApiClient _apiClient;

        public EmployeeController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var interventions = await _apiClient.GetMyInterventionsAsync();
            return View(interventions);
        }

        [HttpGet("{interventionId}")]
        public async Task<IActionResult> Details(int interventionId)
        {
            var intervention = await _apiClient.GetInterventionDetailsAsync(interventionId);
            if (intervention == null) return NotFound();

            var occurrence = await _apiClient.GetOccurrenceDetailsAsync(intervention.OccurrenceId);
            if (occurrence == null) return NotFound();

            var viewModel = new EmployeeInterventionViewModel
            {
                Intervention = intervention,
                Occurrence = occurrence,
                StatusUpdate = new UpdateInterventionStatusDto { Status = intervention.Status }
            };

            return View(viewModel);
        }

        [HttpPost("{interventionId}")] // This route now correctly handles the POST from the form
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int interventionId, [Bind(Prefix = "StatusUpdate")] UpdateInterventionStatusDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid status submitted.";
                return RedirectToAction("Details", new { interventionId });
            }

            var success = await _apiClient.UpdateInterventionStatusAsync(interventionId, dto);
            if (success)
            {
                TempData["SuccessMessage"] = "Task status updated successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update task status. You may not have permission or the task may be cancelled.";
            }

            return RedirectToAction("Details", new { interventionId });
        }
    }
}
```

## File: CondoSphere.Web/Controllers/HomeController.cs
```csharp
using CondoSphere.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CondoSphere.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
```

## File: CondoSphere.Web/Controllers/PortalController.cs
```csharp
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.Web.Controllers
{
    [Authorize(Roles = RoleConstants.CondoResident)]
    [Route("portal")]
    public class PortalController : Controller
    {
        private readonly ApiClient _apiClient;

        public PortalController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            // 1. Call the ApiClient to get the user's occurrences.
            var occurrences = await _apiClient.GetMyOccurrencesAsync();

            // 2. Create an instance of our new ViewModel.
            var viewModel = new PortalDashboardViewModel
            {
                Occurrences = occurrences ?? new List<OccurrenceDto>()
            };

            // 3. Pass the strongly-typed model to the view.
            return View(viewModel);
        }

        [HttpGet("create-occurrence")]
        public IActionResult CreateOccurrence()
        {
            return View(new CreateOccurrenceDto());
        }

        [HttpPost("create-occurrence")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOccurrence(CreateOccurrenceDto model, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _apiClient.CreateOccurrenceAsync(model, imageFile);

            if (result != null)
            {
                TempData["SuccessMessage"] = $"Occurrence '{model.Title}' was reported successfully!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while reporting the occurrence. Please try again.");
            return View(model);
        }

        [HttpGet("occurrences/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var occurrence = await _apiClient.GetOccurrenceDetailsAsync(id);
            if (occurrence == null)
            {
                return NotFound();
            }
            return View(occurrence);
        }
    }
}
```

## File: CondoSphere.Web/Controllers/ProfileController.cs
```csharp
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
```

## File: CondoSphere.Web/Models/AssignManagerViewModel.cs
```csharp
using CondoSphere.Core.DTOs.Condominiums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Web.Models
{
    public class AssignManagerViewModel
    {
        [Required(ErrorMessage = "Please select a manager.")]
        [Display(Name = "Select Manager")]
        public int SelectedManagerId { get; set; }
    }
}
```

## File: CondoSphere.Web/Models/AssignResidentViewModel.cs
```csharp
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Web.Models
{
    public class AssignResidentViewModel
    {
        [Required]
        public int UnitId { get; set; }
        [Required]
        public int CondominiumId { get; set; }

        [Required(ErrorMessage = "Please select a resident to assign.")]
        [Display(Name = "Select an Existing Resident")]
        public int SelectedResidentId { get; set; }

        public IEnumerable<SelectListItem> AvailableResidents { get; set; } = new List<SelectListItem>();
    }
}
```

## File: CondoSphere.Web/Models/ChangePasswordViewModel.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Web.Models
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "The new password must be at least 6 characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Web/Models/CondominiumDetailsViewModel.cs
```csharp
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.DTOs.Occurrences;

namespace CondoSphere.Web.Models
{
    // A new class to hold combined Unit and Resident information for the view
    public class UnitDetailViewModel
    {
        public int Id { get; set; }
        public string Identifier { get; set; } = string.Empty;
        public int? ResidentId { get; set; }
        public string? ResidentName { get; set; }
    }

    public class CondominiumDetailsViewModel
    {
        public CondominiumDto Condominium { get; set; }
        public IEnumerable<UnitDetailViewModel> Units { get; set; } = new List<UnitDetailViewModel>();
        public IEnumerable<OccurrenceDto> Occurrences { get; set; } = new List<OccurrenceDto>();
    }
}
```

## File: CondoSphere.Web/Models/EmployeeInterventionViewModel.cs
```csharp
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.DTOs.Occurrences;

namespace CondoSphere.Web.Models
{
    public class EmployeeInterventionViewModel
    {
        public InterventionDto Intervention { get; set; }
        public OccurrenceDto Occurrence { get; set; }
        public UpdateInterventionStatusDto StatusUpdate { get; set; } = new UpdateInterventionStatusDto();
    }
}
```

## File: CondoSphere.Web/Models/ErrorViewModel.cs
```csharp
namespace CondoSphere.Web.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
```

## File: CondoSphere.Web/Models/ForgotPasswordViewModel.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Web.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Web/Models/InterventionDetailsViewModel.cs
```csharp
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.DTOs.Occurrences;

namespace CondoSphere.Web.Models
{
    public class InterventionDetailsViewModel
    {
        public InterventionDto Intervention { get; set; }
        public OccurrenceDto Occurrence { get; set; }
    }
}
```

## File: CondoSphere.Web/Models/ManagementDashboardViewModel.cs
```csharp
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;

namespace CondoSphere.Web.Models
{
    public class ManagementDashboardViewModel
    {
        public IEnumerable<UserListDto> Users { get; set; } = new List<UserListDto>();
        public IEnumerable<CondominiumDto> Condominiums { get; set; } = new List<CondominiumDto>();
    }
}
```

## File: CondoSphere.Web/Models/MyProfileViewModel.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Web.Models
{
    public class MyProfileViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        public string? CurrentProfileImageUrl { get; set; }

        [Display(Name = "Upload New Profile Image")]
        public IFormFile? ProfileImage { get; set; }
    }
}
```

## File: CondoSphere.Web/Models/OccurrenceDetailsViewModel.cs
```csharp
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.DTOs.Occurrences;

namespace CondoSphere.Web.Models
{
    public class OccurrenceDetailsViewModel
    {
        public OccurrenceDto Occurrence { get; set; }
        public IEnumerable<InterventionDto> Interventions { get; set; } = new List<InterventionDto>();
        public CreateInterventionDto NewIntervention { get; set; } = new CreateInterventionDto();
    }
}
```

## File: CondoSphere.Web/Models/PortalDashboardViewModel.cs
```csharp
using CondoSphere.Core.DTOs.Occurrences;

namespace CondoSphere.Web.Models
{
    public class PortalDashboardViewModel
    {
        public IEnumerable<OccurrenceDto> Occurrences { get; set; } = new List<OccurrenceDto>();
    }
}
```

## File: CondoSphere.Web/Models/RegisterResidentViewModel.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Web.Models
{
    public class RegisterResidentViewModel
    {
        [Required]
        public int UnitId { get; set; }

        [Required]
        public int CondominiumId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Web/Program.cs
```csharp
using CondoSphere.Web.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// --- Add services to the container. ---

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("pt-PT") 
    };

    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

// 1. Configure standard MVC services.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

// 2. Register the handler. It's transient because handlers can have state.
builder.Services.AddTransient<JwtForwardingDelegatingHandler>();

// 3. Configure Authentication services using the "Cookies" scheme.
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        // The name of the cookie that will store our authentication session.
        options.Cookie.Name = "CondoSphere.AuthCookie";
        // If an unauthenticated user tries to access a protected page, redirect them to the Login page.
        options.LoginPath = "/Account/Login";
        // If a logged-in user tries to access a resource they don't have permission for.
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

// 4. Configure Authorization services. This can be expanded with policies later.
builder.Services.AddAuthorization();

// 5. Configure our typed HttpClient for communicating with the API.
builder.Services.AddHttpClient<ApiClient>(client =>
{
    // Set the base URL for all API calls made by this client.
    // This value comes from our appsettings file (e.g., appsettings.Development.json).
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]);
})
.AddHttpMessageHandler<JwtForwardingDelegatingHandler>(); // Attach the handler to the HttpClient pipeline
builder.Services.AddScoped<IImageService, ImageService>();

var app = builder.Build();

// --- Configure the HTTP request pipeline. ---

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRequestLocalization();
app.UseRouting();

// The correct order for authentication middleware in the pipeline:
// 1. UseAuthentication: Identifies who the user is by reading the cookie.
// 2. UseAuthorization: Checks if the identified user has permission to access the requested resource.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```

## File: CondoSphere.Web/Properties/launchSettings.json
```json
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:61532",
      "sslPort": 44394
    }
  },
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "http://localhost:5017",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:7183;http://localhost:5017",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

## File: CondoSphere.Web/Services/ApiClient.cs
```csharp
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.DTOs.Interventions;
using CondoSphere.Core.DTOs.Occurrences;
using CondoSphere.Web.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;

namespace CondoSphere.Web.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDto?> LoginAsync(LoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/login", loginDto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserDto>();
            }

            return null;
        }

        public async Task<bool> RegisterManagerAsync(RegisterManagerDto registerDto)
        {
            // We need to send the token with this request. This is the next major step.
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/register-manager", registerDto);
            return response.IsSuccessStatusCode;
        }

        // --- ADD THESE NEW METHODS ---
        public async Task<IEnumerable<CondominiumDto>> GetCondominiumsAsync()
        {
            // TODO: Add paging parameters
            return await _httpClient.GetFromJsonAsync<IEnumerable<CondominiumDto>>("/api/condominiums");
        }

        public async Task<IEnumerable<UserListDto>> GetUsersAsync()
        {
            // TODO: We need to create this API endpoint next.
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>("/api/accounts/company-users");
        }

        public async Task<IEnumerable<CondominiumDto>> GetMyManagedCondominiumsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CondominiumDto>>("/api/condominiums/my-managed");
        }

        public async Task<CondominiumDto> GetCondominiumDetailsAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CondominiumDto>($"/api/condominiums/{id}");
        }

        public async Task<IEnumerable<UnitDto>> GetUnitsForCondominiumAsync(int condominiumId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UnitDto>>($"/api/condominiums/{condominiumId}/units");
        }

        public async Task<bool> RegisterResidentAsync(int condominiumId, RegisterResidentDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/condominiums/{condominiumId}/residents", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<(bool Success, string Message)> SetPasswordAsync(SetPasswordDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/set-password", dto);
            var responseContent = await response.Content.ReadFromJsonAsync<object>(); // Or a specific response DTO

            if (response.IsSuccessStatusCode)
            {
                // A simple way to get the message back
                var message = responseContent?.GetType().GetProperty("message")?.GetValue(responseContent)?.ToString();
                return (true, message ?? "Password set successfully.");
            }

            // Handle error messages if the API returns them in a structured way
            return (false, "Failed to set password. The link may have expired or the password may not meet complexity requirements.");
        }

        public async Task<bool> CreateCondominiumAsync(CreateUpdateCondominiumDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/condominiums", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<UserListDto>> GetAvailableManagersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>("/api/accounts/managers");
        }

        public async Task<bool> AssignManagerAsync(int condominiumId, AssignManagerDto dto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"/api/condominiums/{condominiumId}/assign-manager", dto);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> CreateUnitAsync(int condominiumId, CreateUpdateUnitDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/condominiums/{condominiumId}/units", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UnassignResidentAsync(int condominiumId, int unitId)
        {
            var response = await _httpClient.PatchAsync($"/api/condominiums/{condominiumId}/units/{unitId}/unassign-resident", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<(bool Success, string Message)> RegisterCompanyAdminAsync(RegisterDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/register-admin", dto);

            var responseContent = await response.Content.ReadFromJsonAsync<object>();

            if (response.IsSuccessStatusCode)
            {
                var message = responseContent?.GetType().GetProperty("message")?.GetValue(responseContent)?.ToString();
                return (true, message ?? "Registration successful! Please check your email to confirm your account.");
            }
            else
            {
                return (false, "Registration failed. The email address may already be in use.");
            }
        }

        public async Task<(bool Success, string Message)> ConfirmEmailAsync(string userId, string token)
        {
            var path = "/api/accounts/confirm-email";

            // 2. Create a dictionary of query parameters.
            var queryParams = new Dictionary<string, string>
            {
                { "userId", userId },
                { "token", token }
            };

            var uri = QueryHelpers.AddQueryString(path, queryParams);

            var response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return (true, "Your email has been successfully confirmed! You can now log in.");
            }
            else
            {
                return (false, "Email could not be confirmed. The link may be invalid or have expired.");
            }
        }

        public async Task<IEnumerable<UserListDto>> GetAvailableResidentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>("/api/accounts/available-residents");
        }

        public async Task<bool> AssignResidentAsync(int condominiumId, int unitId, AssignResidentDto dto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"/api/condominiums/{condominiumId}/units/{unitId}/assign-resident", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeactivateUserAsync(int userId)
        {
            var response = await _httpClient.PostAsync($"/api/accounts/users/{userId}/deactivate", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ActivateUserAsync(int userId)
        {
            var response = await _httpClient.PostAsync($"/api/accounts/users/{userId}/activate", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<OccurrenceDto>> GetOccurrencesForCondominiumAsync(int condominiumId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OccurrenceDto>>($"/api/condominiums/{condominiumId}/occurrences");
        }

        public async Task<IEnumerable<OccurrenceDto>> GetMyOccurrencesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OccurrenceDto>>("/api/occurrences/my-occurrences") ?? new List<OccurrenceDto>();
        }

        public async Task<OccurrenceDto?> CreateOccurrenceAsync(CreateOccurrenceDto dto, IFormFile? imageFile)
        {
            using var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(dto.Title), name: nameof(CreateOccurrenceDto.Title));
            formData.Add(new StringContent(dto.Description), name: nameof(CreateOccurrenceDto.Description));

            if (imageFile != null && imageFile.Length > 0)
            {
                var fileContent = new StreamContent(imageFile.OpenReadStream());
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(imageFile.ContentType);
                formData.Add(fileContent, name: "imageFile", fileName: imageFile.FileName);
            }

            var response = await _httpClient.PostAsync("/api/occurrences", formData);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<OccurrenceDto>();
            }
            return null;
        }

        public async Task<OccurrenceDto?> GetOccurrenceDetailsAsync(int occurrenceId)
        {
            return await _httpClient.GetFromJsonAsync<OccurrenceDto>($"/api/occurrences/{occurrenceId}");
        }

        public async Task<(bool Success, string Message)> ForgotPasswordAsync(string email)
        {
            var requestDto = new ForgotPasswordDto { Email = email };
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/forgot-password", requestDto);
            var message = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, message);
        }

        public async Task<(bool Success, string Message, string? NewToken)> UpdateProfileAsync(UpdateProfileDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/profile", dto);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return (false, responseBody, null);
            }

            try
            {
                using var jsonDoc = JsonDocument.Parse(responseBody);
                jsonDoc.RootElement.TryGetProperty("token", out var tokenElement);
                return (true, "Profile updated successfully.", tokenElement.GetString());
            }
            catch { return (true, "Profile updated successfully.", null); }
        }

        public async Task<(bool Success, string Message)> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/profile/change-password", model);
            var message = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, message);
        }

        public async Task<UserProfileDto?> GetMyProfileAsync()
        {
            return await _httpClient.GetFromJsonAsync<UserProfileDto>("/api/profile");
        }

        public async Task<bool> UpdateOccurrenceStatusAsync(int occurrenceId, UpdateOccurrenceStatusDto dto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"/api/occurrences/{occurrenceId}/status", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<InterventionDto>> GetInterventionsForOccurrenceAsync(int occurrenceId)
        {
            var response = await _httpClient.GetAsync($"/api/occurrences/{occurrenceId}/interventions");
            if (!response.IsSuccessStatusCode)
            {
                return new List<InterventionDto>();
            }
            return await response.Content.ReadFromJsonAsync<IEnumerable<InterventionDto>>() ?? new List<InterventionDto>();
        }

        public async Task<InterventionDto?> CreateInterventionAsync(CreateInterventionDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/interventions", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<InterventionDto>();
            }
            return null;
        }

        public async Task<bool> RegisterEmployeeAsync(RegisterManagerDto registerDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/register-employee", registerDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<UserListDto>> GetAvailableEmployeesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>("/api/accounts/employees") ?? new List<UserListDto>();
        }

        public async Task<IEnumerable<InterventionDto>> GetMyInterventionsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<InterventionDto>>("/api/interventions/my-tasks") ?? new List<InterventionDto>();
        }

        public async Task<bool> UpdateInterventionStatusAsync(int interventionId, UpdateInterventionStatusDto dto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"/api/interventions/{interventionId}/status", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<InterventionDto?> GetInterventionDetailsAsync(int interventionId)
        {
            var response = await _httpClient.GetAsync($"/api/interventions/{interventionId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<InterventionDto>();
            }
            return null;
        }
    }
}
```

## File: CondoSphere.Web/Services/IImageService.cs
```csharp
namespace CondoSphere.Web.Services
{
    public interface IImageService
    {
        Task<string> SaveImageAsync(IFormFile imageFile, string folder, string? currentImagePath = null);
    }
}
```

## File: CondoSphere.Web/Services/ImageService.cs
```csharp
namespace CondoSphere.Web.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _env;

        public ImageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SaveImageAsync(IFormFile imageFile, string folder, string? currentImagePath = null)
        {
            if (!string.IsNullOrEmpty(currentImagePath))
            {
                var oldFullPath = Path.Combine(_env.WebRootPath, currentImagePath.TrimStart('/'));
                if (File.Exists(oldFullPath))
                {
                    File.Delete(oldFullPath);
                }
            }

            var uploadsFolder = Path.Combine(_env.WebRootPath, "images", folder);
            if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(imageFile.FileName)}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return $"/images/{folder}/{uniqueFileName}";
        }
    }
}
```

## File: CondoSphere.Web/Services/JwtForwardingDelegatingHandler.cs
```csharp
using System.Net.Http.Headers;

namespace CondoSphere.Web.Services
{
    public class JwtForwardingDelegatingHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtForwardingDelegatingHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Try to get the access_token from the authenticated user's claims
            var token = _httpContextAccessor.HttpContext?.User.FindFirst("access_token")?.Value;

            // If a token is found, add it to the outgoing request's Authorization header
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
```

## File: CondoSphere.Web/Views/_ViewImports.cshtml
```
@using CondoSphere.Web
@using CondoSphere.Web.Models
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

## File: CondoSphere.Web/Views/_ViewStart.cshtml
```
@{
    Layout = "_Layout";
}
```

## File: CondoSphere.Web/Views/Account/ForgotPassword.cshtml
```
@model CondoSphere.Web.Models.ForgotPasswordViewModel

@{
    ViewData["Title"] = "Forgot Your Password?";
}

<h1>@ViewData["Title"]</h1>
<p>Enter your email address and we will send you a link to reset your password.</p>
<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="ForgotPassword" method="post">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <div class="form-floating mb-3">
                <input asp-for="Email" class="form-control" autocomplete="username" aria-required="true" />
                <label asp-for="Email" class="form-label"></label>
                <span asp-validation-for="Email" class="text-danger"></span>
            </div>
            <button type="submit" class="w-100 btn btn-primary">Send Reset Link</button>
        </form>
    </div>
</div>
```

## File: CondoSphere.Web/Views/Account/ForgotPasswordConfirmation.cshtml
```
@{
    ViewData["Title"] = "Forgot Password Confirmation";
}

<div class="text-center">
    <h1>@ViewData["Title"]</h1>
    <hr />
    <p>
        @ViewData["Message"]
    </p>
</div>
```

## File: CondoSphere.Web/Views/Account/Login.cshtml
```
@model CondoSphere.Core.DTOs.Account.LoginDto

@{
    ViewData["Title"] = "Log in";
}

<h1>@ViewData["Title"]</h1>
<div class="row">
    <div class="col-md-4">
        <section>
            <form id="account" method="post">
                @Html.AntiForgeryToken()
                <hr />
                <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                <div class="form-floating mb-3">
                    <input asp-for="Email" class="form-control" autocomplete="username" aria-required="true" />
                    <label asp-for="Email" class="form-label"></label>
                    <span asp-validation-for="Email" class="text-danger"></span>
                </div>
                <div class="form-floating mb-3">
                    <input asp-for="Password" class="form-control" type="password" autocomplete="current-password" aria-required="true" />
                    <label asp-for="Password" class="form-label"></label>
                    <span asp-validation-for="Password" class="text-danger"></span>
                </div>
                <div>
                    <button id="login-submit" type="submit" class="w-100 btn btn-lg btn-primary">Log in</button>
                </div>
                <div class="mt-3 text-center">
                    <p>
                        <a asp-action="ForgotPassword">Forgot your password?</a>
                    </p>
                </div>
            </form>
        </section>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## File: CondoSphere.Web/Views/Account/Register.cshtml
```
@model CondoSphere.Core.DTOs.Account.RegisterDto

@{
    ViewData["Title"] = "Register a New Company";
}

<h1>@ViewData["Title"]</h1>
<p class="text-muted">Sign up to start managing your condominiums with CondoSphere.</p>
<hr />

<div class="row">
    <div class="col-md-6">
        <form asp-action="Register" method="post">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <h4>Company Information</h4>
            <div class="form-floating mb-3">
                <input asp-for="CompanyName" class="form-control" placeholder="Your Company LLC" />
                <label asp-for="CompanyName"></label>
                <span asp-validation-for="CompanyName" class="text-danger"></span>
            </div>

            <h4 class="mt-4">Your Administrator Account</h4>
            <div class="form-floating mb-3">
                <input asp-for="FirstName" class="form-control" placeholder="John" />
                <label asp-for="FirstName"></label>
                <span asp-validation-for="FirstName" class="text-danger"></span>
            </div>
            <div class="form-floating mb-3">
                <input asp-for="LastName" class="form-control" placeholder="Doe" />
                <label asp-for="LastName"></label>
                <span asp-validation-for="LastName" class="text-danger"></span>
            </div>
            <div class="form-floating mb-3">
                <input asp-for="Email" class="form-control" placeholder="you@example.com" />
                <label asp-for="Email"></label>
                <span asp-validation-for="Email" class="text-danger"></span>
            </div>
            <div class="form-floating mb-3">
                <input asp-for="Password" type="password" class="form-control" />
                <label asp-for="Password"></label>
                <span asp-validation-for="Password" class="text-danger"></span>
            </div>
            <div class="form-floating mb-3">
                <input asp-for="ConfirmPassword" type="password" class="form-control" />
                <label asp-for="ConfirmPassword"></label>
                <span asp-validation-for="ConfirmPassword" class="text-danger"></span>
            </div>

            <button type="submit" class="w-100 btn btn-lg btn-primary">Register</button>
        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## File: CondoSphere.Web/Views/Account/RegistrationComplete.cshtml
```
@{
    ViewData["Title"] = "Registration Complete";
}

<div class="text-center">
    <h1 class="display-4"><i class="bi bi-check-circle-fill text-success"></i> Thank You!</h1>
    <p class="lead">Your company and administrator account have been created successfully.</p>
    <hr />
    <p class="h5">
        <strong>A confirmation email has been sent to your address.</strong>
    </p>
    <p>
        Please click the link in the email to activate your account before you can log in.
    </p>
    <div class="mt-4">
        <a class="btn btn-primary" asp-action="Login">Proceed to Login Page</a>
    </div>
</div>
```

## File: CondoSphere.Web/Views/Account/SetPassword.cshtml
```
@model CondoSphere.Core.DTOs.Account.SetPasswordDto

@{
    ViewData["Title"] = "Set Your Password";
}

<h1>@ViewData["Title"]</h1>
<h4>Complete your account registration by setting a secure password.</h4>
<hr />

<div class="row">
    <div class="col-md-6">
        <form asp-action="SetPassword" method="post">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <input type="hidden" asp-for="UserId" />
            <input type="hidden" asp-for="Token" />

            <div class="form-floating mb-3">
                <input asp-for="Password" class="form-control" type="password" />
                <label asp-for="Password"></label>
                <span asp-validation-for="Password" class="text-danger"></span>
            </div>

            <div class="form-floating mb-3">
                <input asp-for="ConfirmPassword" class="form-control" type="password" />
                <label asp-for="ConfirmPassword"></label>
                <span asp-validation-for="ConfirmPassword" class="text-danger"></span>
            </div>

            <button type="submit" class="btn btn-primary">Set Password</button>
        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## File: CondoSphere.Web/Views/Administration/AssignManager.cshtml
```
@model AssignManagerViewModel
@{
    ViewData["Title"] = "Assign Manager";
    // Retrieve the display data from ViewData
    var condominium = ViewData["Condominium"] as CondoSphere.Core.DTOs.Condominiums.CondominiumDto;
    var availableManagers = ViewData["AvailableManagers"] as IEnumerable<SelectListItem>;
}

<h1>@ViewData["Title"]</h1>
<hr />
<h4>Condominium: <strong>@condominium.Name</strong></h4>
<p>Select a manager from the list below to assign them to this condominium.</p>

<div class="row">
    <div class="col-md-6">
        <form asp-action="AssignManager" asp-route-condominiumId="@condominium.Id" method="post">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <div class="form-group mb-3">
                <label asp-for="SelectedManagerId" class="form-label"></label>
                <select asp-for="SelectedManagerId" asp-items="availableManagers" class="form-control">
                    <option value="">-- Please select a manager --</option>
                </select>
                <span asp-validation-for="SelectedManagerId" class="text-danger"></span>
            </div>

            <button type="submit" class="btn btn-primary">Assign Manager</button>
            <a asp-action="Index" class="btn btn-secondary">Cancel</a>
        </form>
    </div>
</div>
```

## File: CondoSphere.Web/Views/Administration/CreateCondominium.cshtml
```
@model CondoSphere.Core.DTOs.Condominiums.CreateUpdateCondominiumDto

@{
    ViewData["Title"] = "Create New Condominium";
}

<h1>@ViewData["Title"]</h1>
<hr />

<div class="row">
    <div class="col-md-6">
        <form asp-action="CreateCondominium" method="post">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <div class="form-floating mb-3">
                <input asp-for="Name" class="form-control" placeholder="e.g., Central Park Residences" />
                <label asp-for="Name"></label>
                <span asp-validation-for="Name" class="text-danger"></span>
            </div>

            <div class="form-floating mb-3">
                <input asp-for="Address" class="form-control" placeholder="e.g., 123 Main Street, Anytown" />
                <label asp-for="Address"></label>
                <span asp-validation-for="Address" class="text-danger"></span>
            </div>

            <button type="submit" class="btn btn-success">Create Condominium</button>
            <a asp-action="Index" class="btn btn-secondary">Cancel</a>
        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## File: CondoSphere.Web/Views/Administration/Index.cshtml
```
@model ManagementDashboardViewModel
@using CondoSphere.Core

@{
    ViewData["Title"] = "Admin Dashboard";
    var currentUserId = (int)ViewData["CurrentUserId"];
}

<div class="d-flex justify-content-between align-items-center mb-4">
    <div>
        <h1>@ViewData["Title"]</h1>
        <p class="text-muted">Manage your company's condominiums and users.</p>
    </div>
    <div>
        <a class="btn btn-primary" asp-action="RegisterManager">
            <i class="bi bi-person-plus-fill me-1"></i> Register New Manager
        </a>
        <a class="btn btn-info" asp-action="RegisterEmployee">
            <i class="bi bi-person-plus me-1"></i> Register Employee
        </a>
        <a class="btn btn-success" asp-action="CreateCondominium">
            <i class="bi bi-building-fill-add me-1"></i> Create Condominium
        </a>
    </div>
</div>

<div class="row">
    <div class="col-lg-7">
        <div class="card shadow-sm mb-4">
            <div class="card-header">
                <h5 class="mb-0">Managed Condominiums</h5>
            </div>
            <div class="card-body p-0">
                @if (Model.Condominiums.Any())
                {
                    <div class="table-responsive">
                        <table class="table table-hover mb-0 align-middle">
                            <thead>
                                <tr>
                                    <th scope="col">Name</th>
                                    <th scope="col">Address</th>
                                    <th scope="col">Assigned Manager</th>
                                    <th scope="col" class="text-end">Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                @foreach (var condo in Model.Condominiums)
                                {
                                    <tr>
                                        <td>@condo.Name</td>
                                        <td>@condo.Address</td>
                                        <td>
                                            @if (!string.IsNullOrEmpty(condo.ManagerName))
                                            {
                                                <span class="text-muted">@condo.ManagerName</span>
                                            }
                                        </td>
                                        <td class="text-end">
                                            @if (string.IsNullOrEmpty(condo.ManagerName))
                                            {
                                                <a asp-action="AssignManager" asp-route-condominiumId="@condo.Id" class="btn btn-sm btn-primary">Assign Manager</a>
                                            }
                                            else
                                            {
                                                <a asp-action="AssignManager" asp-route-condominiumId="@condo.Id" class="btn btn-sm btn-outline-secondary">Re-assign</a>
                                            }
                                        </td>
                                    </tr>
                                }
                            </tbody>
                        </table>
                    </div>
                }
                else
                {
                    <div class="text-center p-4">
                        <p class="text-muted mb-0">No condominiums have been created yet. Click the "Create Condominium" button to get started.</p>
                    </div>
                }
            </div>
        </div>
    </div>

    <div class="col-lg-5">
        <div class="card shadow-sm mb-4">
            <div class="card-header">
                <h5 class="mb-0">Company Users</h5>
            </div>
            <div class="card-body p-0">
                @if (Model.Users.Any())
                {
                    <div class="table-responsive">
                        <table class="table table-hover mb-0 align-middle">
                            <thead>
                                <tr>
                                    <th scope="col">Name</th>
                                    <th scope="col">Role</th>
                                    <th scope="col">Status</th>
                                    <th scope="col">Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                @foreach (var user in Model.Users)
                                {
                                    <tr>
                                        <td>@user.FirstName @user.LastName<br /><small class="text-muted">@user.Email</small></td>
                                        <td><span class="badge bg-secondary">@user.Role</span></td>
                                        <td>
                                            @if (user.IsActive)
                                            {
                                                <span class="badge bg-success">Active</span>
                                            }
                                            else
                                            {
                                                <span class="badge bg-danger">Inactive</span>
                                            }
                                        </td>
                                        <td>
                                            @if (user.Id != currentUserId)
                                            {
                                                if (user.IsActive)
                                                {
                                                    <form asp-action="DeactivateUser" asp-route-userId="@user.Id" method="post" onsubmit="return confirm('Are you sure you want to deactivate this user?');">
                                                        @Html.AntiForgeryToken()
                                                        <button type="submit" class="btn btn-sm btn-outline-warning">Deactivate</button>
                                                    </form>
                                                }
                                                else
                                                {
                                                    <form asp-action="ActivateUser" asp-route-userId="@user.Id" method="post">
                                                        @Html.AntiForgeryToken()
                                                        <button type="submit" class="btn btn-sm btn-outline-success">Activate</button>
                                                    </form>
                                                }
                                            }
                                        </td>
                                    </tr>
                                }
                            </tbody>
                        </table>
                    </div>
                }
                else
                {
                    <div class="text-center p-4">
                        <p class="text-muted mb-0">No users found.</p>
                    </div>
                }
            </div>
        </div>
    </div>
</div>
```

## File: CondoSphere.Web/Views/Administration/RegisterEmployee.cshtml
```
@model CondoSphere.Core.DTOs.Account.RegisterManagerDto

@{
    ViewData["Title"] = "Register New Employee";
}

<h1>@ViewData["Title"]</h1>
<hr />

<div class="row">
    <div class="col-md-6">
        <form asp-action="RegisterEmployee" method="post">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <div class="form-floating mb-3">
                <input asp-for="FirstName" class="form-control" />
                <label asp-for="FirstName"></label>
                <span asp-validation-for="FirstName" class="text-danger"></span>
            </div>

            <div class="form-floating mb-3">
                <input asp-for="LastName" class="form-control" />
                <label asp-for="LastName"></label>
                <span asp-validation-for="LastName" class="text-danger"></span>
            </div>

            <div class="form-floating mb-3">
                <input asp-for="Email" class="form-control" />
                <label asp-for="Email"></label>
                <span asp-validation-for="Email" class="text-danger"></span>
            </div>

            <button type="submit" class="btn btn-primary">Register Employee</button>
            <a asp-action="Index" class="btn btn-secondary">Cancel</a>
        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## File: CondoSphere.Web/Views/Administration/RegisterManager.cshtml
```
@model CondoSphere.Core.DTOs.Account.RegisterManagerDto

@{
    ViewData["Title"] = "Register New Manager";
}

<h1>@ViewData["Title"]</h1>
<hr />

<div class="row">
    <div class="col-md-6">
        <form asp-action="RegisterManager" method="post">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <div class="form-floating mb-3">
                <input asp-for="FirstName" class="form-control" />
                <label asp-for="FirstName"></label>
                <span asp-validation-for="FirstName" class="text-danger"></span>
            </div>

            <div class="form-floating mb-3">
                <input asp-for="LastName" class="form-control" />
                <label asp-for="LastName"></label>
                <span asp-validation-for="LastName" class="text-danger"></span>
            </div>

            <div class="form-floating mb-3">
                <input asp-for="Email" class="form-control" />
                <label asp-for="Email"></label>
                <span asp-validation-for="Email" class="text-danger"></span>
            </div>

            <button type="submit" class="btn btn-primary">Register Manager</button>
            <a asp-action="Index" class="btn btn-secondary">Cancel</a>
        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## File: CondoSphere.Web/Views/CondoManagement/AssignResident.cshtml
```
@model CondoSphere.Web.Models.AssignResidentViewModel

@{
    ViewData["Title"] = "Assign Resident to Unit";
}

<h1>@ViewData["Title"]</h1>
<p>You are assigning a resident to <strong>Unit ID @Model.UnitId</strong>.</p>
<hr />

<div class="row">
    <div class="col-md-6">
        @* We can add a tabbed interface here later to include the "Register New" form *@
        <form asp-action="AssignResident" method="post">
            <input type="hidden" asp-for="UnitId" />
            <input type="hidden" asp-for="CondominiumId" />
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <div class="form-group mb-3">
                <label asp-for="SelectedResidentId" class="form-label"></label>
                <select asp-for="SelectedResidentId" asp-items="Model.AvailableResidents" class="form-control">
                    <option value="">-- Please select a resident --</option>
                </select>
                <span asp-validation-for="SelectedResidentId" class="text-danger"></span>
            </div>

            <button type="submit" class="btn btn-primary">Assign Resident</button>
            <a asp-action="Details" asp-route-id="@Model.CondominiumId" class="btn btn-secondary">Cancel</a>
        </form>
    </div>
</div>
```

## File: CondoSphere.Web/Views/CondoManagement/CreateUnit.cshtml
```
@model CondoSphere.Core.DTOs.Condominiums.CreateUpdateUnitDto

@{
    ViewData["Title"] = "Add New Unit";
    var condominiumId = ViewData["CondominiumId"];
}

<h1>@ViewData["Title"]</h1>
<hr />

<div class="row">
    <div class="col-md-6">
        <form asp-action="CreateUnit" asp-route-condominiumId="@condominiumId" method="post">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <div class="form-floating mb-3">
                <input asp-for="Identifier" class="form-control" placeholder="e.g., Apt 101, Block B - Floor 2" />
                <label asp-for="Identifier">Unit Identifier</label>
                <span asp-validation-for="Identifier" class="text-danger"></span>
            </div>

            <button type="submit" class="btn btn-success">Create Unit</button>
            <a asp-action="Details" asp-route-id="@condominiumId" class="btn btn-secondary">Cancel</a>
        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## File: CondoSphere.Web/Views/CondoManagement/Details.cshtml
```
@model CondoSphere.Web.Models.CondominiumDetailsViewModel

@{
    ViewData["Title"] = $"Manage: {Model.Condominium.Name}";
}

<div class="d-flex justify-content-between align-items-center mb-4">
    <div>
        <h1>@Model.Condominium.Name</h1>
        <p class="text-muted mb-0">@Model.Condominium.Address</p>
    </div>
    <div>
        <a asp-action="CreateUnit" asp-route-condominiumId="@Model.Condominium.Id" class="btn btn-success">
            <i class="bi bi-plus-square-fill me-1"></i> Add New Unit
        </a>
    </div>
</div>

<div class="card shadow-sm">
    <div class="card-header">
        <h5 class="mb-0">Units</h5>
    </div>
    <div class="card-body p-0">
        @if (Model.Units.Any())
        {
            <div class="table-responsive">
                <table class="table table-hover mb-0 align-middle">
                    <thead>
                        <tr>
                            <th scope="col">Identifier</th>
                            <th scope="col">Status / Resident</th>
                            <th scope="col" class="text-end">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        @foreach (var unit in Model.Units)
                        {
                            <tr>
                                <td><strong>@unit.Identifier</strong></td>
                                <td>
                                    @if (unit.ResidentId.HasValue)
                                    {
                                        <span class="badge bg-info">Occupied</span>
                                        <span class="ms-2">@unit.ResidentName</span>
                                    }
                                    else
                                    {
                                        <a asp-action="AssignResident"
                                           asp-route-unitId="@unit.Id"
                                           asp-route-condominiumId="@Model.Condominium.Id"
                                           class="btn btn-sm btn-primary">Assign Resident</a>
                                    }
                                </td>
                                <td class="text-end">
                                    @if (unit.ResidentId.HasValue)
                                    {
                                        <form asp-action="UnassignResident" asp-route-condominiumId="@Model.Condominium.Id" asp-route-unitId="@unit.Id" method="post" onsubmit="return confirm('Are you sure you want to unassign this resident? Their account will be deactivated.');">
                                            @Html.AntiForgeryToken()
                                            <button type="submit" class="btn btn-sm btn-outline-danger">Unassign Resident</button>
                                        </form>
                                    }
                                    else
                                    {
                                        <a asp-action="RegisterResident"
                                           asp-route-unitId="@unit.Id"
                                           asp-route-condominiumId="@Model.Condominium.Id"
                                           class="btn btn-sm btn-primary">Register Resident</a>
                                    }
                                </td>
                            </tr>
                        }
                    </tbody>
                </table>
            </div>
        }
        else
        {
            <div class="text-center p-4">
                <p class="text-muted mb-0">No units have been created for this condominium yet.</p>
            </div>
        }
    </div>
</div>

<div class="mt-4">
    <a asp-action="Index" class="btn btn-outline-secondary">
        <i class="bi bi-arrow-left me-1"></i> Back to My Condos
    </a>
</div>
<hr class="my-4" />

<div class="card shadow-sm">
    <div class="card-header">
        <h5 class="mb-0">Reported Occurrences</h5>
    </div>
    <div class="card-body p-0">
        @if (Model.Occurrences.Any())
        {
            <div class="table-responsive">
                <table class="table table-hover mb-0 align-middle">
                    <thead>
                        <tr>
                            <th scope="col">Title</th>
                            <th scope="col">Reported By</th>
                            <th scope="col">Date</th>
                            <th scope="col">Status</th>
                            <th scope="col" class="text-end">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        @foreach (var occurrence in Model.Occurrences)
                        {
                            <tr>
                                <td><strong>@occurrence.Title</strong></td>
                                <td>@occurrence.ReportedByUserName</td>
                                <td>@occurrence.ReportedDate.ToString("yyyy-MM-dd HH:mm")</td>
                                <td>
                                    <span class="badge bg-danger">@occurrence.Status</span>
                                </td>
                                <td class="text-end">
                                    @* ===== REPLACE THIS LINK ===== *@
                                    <a asp-action="OccurrenceDetails"
                                       asp-route-condominiumId="@Model.Condominium.Id"
                                       asp-route-occurrenceId="@occurrence.Id"
                                       class="btn btn-sm btn-outline-primary">View Details</a>
                                </td>
                            </tr>
                        }
                    </tbody>
                </table>
            </div>
        }
        else
        {
            <div class="text-center p-4">
                <p class="text-muted mb-0">No occurrences have been reported for this condominium yet.</p>
            </div>
        }
    </div>
</div>
```

## File: CondoSphere.Web/Views/CondoManagement/Index.cshtml
```
@model IEnumerable<CondoSphere.Core.DTOs.Condominiums.CondominiumDto>

@{
    ViewData["Title"] = "My Managed Condominiums";
}

<div class="d-flex justify-content-between align-items-center mb-4">
    <div>
        <h1>@ViewData["Title"]</h1>
        <p class="text-muted">Select a condominium to manage its units and residents.</p>
    </div>
</div>

@if (Model.Any())
{
    <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
        @foreach (var condo in Model)
        {
            <div class="col">
                <div class="card h-100 shadow-sm">
                    <div class="card-body">
                        <h5 class="card-title">@condo.Name</h5>
                        <p class="card-text text-muted">@condo.Address</p>
                    </div>
                    <div class="card-footer bg-transparent border-top-0 text-end">
                        <a asp-controller="CondoManagement" asp-action="Details" asp-route-id="@condo.Id" class="btn btn-primary">
                            <i class="bi bi-gear-fill me-1"></i> Manage
                        </a>
                    </div>
                </div>
            </div>
        }
    </div>
}
else
{
    <div class="text-center p-5">
        <h3 class="text-muted">No Condominiums Assigned</h3>
        <p>You have not been assigned to manage any condominiums yet. Please contact your company administrator.</p>
    </div>
}
```

## File: CondoSphere.Web/Views/CondoManagement/OccurrenceDetails.cshtml
```
@model CondoSphere.Web.Models.OccurrenceDetailsViewModel
@using CondoSphere.Core.Enums
@using CondoSphere.Core.DTOs.Occurrences
@using Microsoft.AspNetCore.Mvc.Rendering

@{
    ViewData["Title"] = "Occurrence Details";
    // This value is used to prevent selecting past dates in the calendar input.
    var minDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");
    // This flag determines if the "Add Intervention" button should be enabled.
    var employeesExist = (ViewData["AvailableEmployees"] as SelectList)?.Any() ?? false;
}

<h1>@Model.Occurrence.Title</h1>
<p class="text-muted">Details for occurrence reported on @Model.Occurrence.ReportedDate.ToLocalTime().ToString("f")</p>
<hr />

<div class="row">
    <div class="col-md-8">
        @* ===== CARD 1: OCCURRENCE DETAILS & STATUS UPDATE ===== *@
        <div class="card mb-4 shadow-sm">
            <div class="card-header d-flex justify-content-between align-items-center">
                <h5 class="mb-0">Details</h5>

                <form asp-action="UpdateOccurrenceStatus"
                      asp-route-condominiumId="@Model.Occurrence.CondominiumId"
                      asp-route-occurrenceId="@Model.Occurrence.Id"
                      method="post" class="d-flex align-items-center gap-2">
                    @Html.AntiForgeryToken()
                    <label for="Status" class="form-label mb-0 me-2"><strong>Change Status:</strong></label>
                    <select name="Status" class="form-select form-select-sm w-auto"
                            asp-for="Occurrence.Status"
                            asp-items="Html.GetEnumSelectList<OccurrenceStatus>()">
                    </select>
                    <button type="submit" class="btn btn-primary btn-sm">Update</button>
                </form>
            </div>
            <div class="card-body">
                <dl class="row">
                    <dt class="col-sm-3">Current Status</dt>
                    <dd class="col-sm-9">
                        @{
                            var statusClass = "bg-secondary";
                            switch (Model.Occurrence.Status)
                            {
                                case OccurrenceStatus.Open: statusClass = "bg-danger"; break;
                                case OccurrenceStatus.InProgress: statusClass = "bg-warning text-dark"; break;
                                case OccurrenceStatus.Resolved: statusClass = "bg-info"; break;
                                case OccurrenceStatus.Closed: statusClass = "bg-success"; break;
                            }
                        }
                        <span class="badge @statusClass fs-6">@Model.Occurrence.Status</span>
                    </dd>

                    <dt class="col-sm-3">Reported On</dt>
                    <dd class="col-sm-9">@Model.Occurrence.ReportedDate.ToLocalTime().ToString("f")</dd>

                    <dt class="col-sm-3">Reported By</dt>
                    <dd class="col-sm-9">@Model.Occurrence.ReportedByUserName</dd>
                </dl>
                <hr />
                <h5>Description</h5>
                <p>@Model.Occurrence.Description</p>
            </div>
        </div>

        @* ===== CARD 2: INTERVENTIONS LIST ===== *@
        <div class="card shadow-sm">
            <div class="card-header d-flex justify-content-between align-items-center">
                <h5 class="mb-0">Interventions</h5>
                @if (employeesExist)
                {
                    <button type="button" class="btn btn-primary btn-sm" data-bs-toggle="modal" data-bs-target="#addInterventionModal">
                        <i class="bi bi-plus-circle-fill me-1"></i> Add Intervention
                    </button>
                }
                else
                {
                    <span class="d-inline-block" tabindex="0" data-bs-toggle="tooltip" title="You must register an employee before you can create an intervention.">
                        <button type="button" class="btn btn-primary btn-sm" disabled>
                            <i class="bi bi-plus-circle-fill me-1"></i> Add Intervention
                        </button>
                    </span>
                }
            </div>
            <div class="card-body p-0">
                @if (Model.Interventions.Any())
                {
                    <div class="table-responsive">
                        <table class="table table-hover mb-0 align-middle">
                            <thead>
                                <tr>
                                    <th>Description</th>
                                    <th>Start Date</th>
                                    <th>Assigned To</th>
                                    <th style="width: 250px;">Status</th>
                                </tr>
                            </thead>

                            <tbody>
                                @foreach (var intervention in Model.Interventions)
                                {
                                    <tr>
                                        <td>@intervention.Description</td>
                                        <td>@intervention.StartDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm")</td>
                                        <td>
                                            @if (!string.IsNullOrEmpty(intervention.AssignedToUserName))
                                            {
                                                @intervention.AssignedToUserName
                                            }
                                            else
                                            {
                                                <span class="text-muted fst-italic">Unassigned</span>
                                            }
                                        </td>
                                        <td>
                                            @if (intervention.Status == InterventionStatus.Cancelled)
                                            {
                                                @* If the intervention is cancelled, just show a static, non-editable badge. *@
                                                <span class="badge bg-danger">@intervention.Status</span>
                                            }
                                            else
                                            {
                                                @* Otherwise, render the interactive container for display and editing. *@
                                                <div class="intervention-status-container">

                                                    @* State 1: Display Mode (Visible by default) *@
                                                    <div class="status-display">
                                                        @{
                                                            var interventionStatusClass = "bg-secondary"; // Default color
                                                            switch (intervention.Status)
                                                            {
                                                                case InterventionStatus.Scheduled: interventionStatusClass = "bg-info"; break;
                                                                case InterventionStatus.InProgress: interventionStatusClass = "bg-warning text-dark"; break;
                                                                case InterventionStatus.Completed: interventionStatusClass = "bg-success"; break;
                                                            }
                                                        }
                                                        <span class="badge @interventionStatusClass">@intervention.Status</span>
                                                        <button type="button" class="btn btn-link btn-sm p-0 ms-2 edit-status-btn" title="Change Status">
                                                            <i class="bi bi-pencil-square"></i>
                                                        </button>
                                                    </div>

                                                    @* State 2: Edit Mode (Hidden by default) *@
                                                    <form asp-action="UpdateInterventionStatus"
                                                          asp-route-condominiumId="@Model.Occurrence.CondominiumId"
                                                          asp-route-occurrenceId="@Model.Occurrence.Id"
                                                          asp-route-interventionId="@intervention.Id"
                                                          method="post" class="status-edit-form d-none">
                                                        @Html.AntiForgeryToken()
                                                        <div class="input-group input-group-sm">
                                                            <select name="Status" class="form-select">
                                                                @foreach (var statusValue in Html.GetEnumSelectList<InterventionStatus>())
                                                                {
                                                                    <option value="@statusValue.Value" selected="@(intervention.Status.ToString() == statusValue.Value)">
                                                                        @statusValue.Text
                                                                    </option>
                                                                }
                                                            </select>
                                                            <button type="submit" class="btn btn-primary">Update</button>
                                                            <button type="button" class="btn btn-secondary cancel-edit-btn">Cancel</button>
                                                        </div>
                                                    </form>

                                                </div>
                                            }
                                        </td>
                                    </tr>
                                }
                            </tbody>


                        </table>
                    </div>
                }
                else
                {
                    <div class="text-center p-4">
                        <p class="text-muted mb-0">No interventions have been created for this occurrence yet.</p>
                    </div>
                }
            </div>
        </div>

        <div class="mt-3">
            <a asp-action="Details" asp-route-id="@Model.Occurrence.CondominiumId" class="btn btn-secondary">Back to Condominium Details</a>
        </div>
    </div>
    <div class="col-md-4">
        @* ===== CARD 3: ATTACHED IMAGE ===== *@
        @if (!string.IsNullOrEmpty(Model.Occurrence.ImageUrl))
        {
            <div class="card shadow-sm">
                <div class="card-header">
                    Attached Image
                </div>
                <div class="card-body p-1">
                    <a href="@Model.Occurrence.ImageUrl" target="_blank" title="Click to view full size">
                        <img src="@Model.Occurrence.ImageUrl" alt="Occurrence Image" class="img-fluid rounded" />
                    </a>
                </div>
            </div>
        }
        else
        {
            <div class="card bg-light shadow-sm">
                <div class="card-body text-center text-muted">
                    <i class="bi bi-image-alt fs-1"></i>
                    <p>No image was provided.</p>
                </div>
            </div>
        }
    </div>
</div>

@* ===== MODAL: ADD INTERVENTION ===== *@
<div class="modal fade" id="addInterventionModal" tabindex="-1" aria-labelledby="addInterventionModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <form asp-action="CreateIntervention"
                  asp-route-condominiumId="@Model.Occurrence.CondominiumId"
                  asp-route-occurrenceId="@Model.Occurrence.Id"
                  method="post">
                <div class="modal-header">
                    <h5 class="modal-title" id="addInterventionModalLabel">Add New Intervention</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    @Html.AntiForgeryToken()
                    <input type="hidden" asp-for="NewIntervention.OccurrenceId" />

                    <div class="mb-3">
                        <label asp-for="NewIntervention.Description" class="form-label"></label>
                        <textarea asp-for="NewIntervention.Description" class="form-control" rows="3"></textarea>
                        <span asp-validation-for="NewIntervention.Description" class="text-danger"></span>
                    </div>
                    <div class="mb-3">
                        <label asp-for="NewIntervention.StartDate" class="form-label"></label>
                        <input asp-for="NewIntervention.StartDate"
                               asp-format="{0:yyyy-MM-ddTHH:mm}"
                               class="form-control"
                               type="datetime-local"
                               min="@minDateTime" />
                        <span asp-validation-for="NewIntervention.StartDate" class="text-danger"></span>
                    </div>
                    <div class="mb-3">
                        <label asp-for="NewIntervention.AssignedToUserId" class="form-label">Assign To</label>
                        <select asp-for="NewIntervention.AssignedToUserId"
                                asp-items="@(ViewData["AvailableEmployees"] as SelectList)"
                                class="form-select">
                        </select>
                        <span asp-validation-for="NewIntervention.AssignedToUserId" class="text-danger"></span>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="submit" class="btn btn-primary">Save Intervention</button>
                </div>
            </form>
        </div>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />

    @if (!ViewContext.ModelState.IsValid && ViewContext.ModelState.Keys.Any(k => k.StartsWith("NewIntervention")))
    {
        <script>
            document.addEventListener('DOMContentLoaded', function () {
                var interventionModal = new bootstrap.Modal(document.getElementById('addInterventionModal'));
                interventionModal.show();
            });
        </script>
    }

    <script>
        // Standard Bootstrap 5 script to initialize all tooltips on the page
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
        var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl)
        })
    </script>

    <script>
        document.addEventListener('DOMContentLoaded', function () {
            const containers = document.querySelectorAll('.intervention-status-container');

            containers.forEach(container => {
                const displayDiv = container.querySelector('.status-display');
                const editForm = container.querySelector('.status-edit-form');
                const editBtn = container.querySelector('.edit-status-btn');
                const cancelBtn = container.querySelector('.cancel-edit-btn');

                editBtn.addEventListener('click', function () {
                    displayDiv.classList.add('d-none');
                    editForm.classList.remove('d-none');
                });

                cancelBtn.addEventListener('click', function () {
                    editForm.classList.add('d-none');
                    displayDiv.classList.remove('d-none');
                });
            });
        });
    </script>
}
```

## File: CondoSphere.Web/Views/CondoManagement/RegisterResident.cshtml
```
@model CondoSphere.Web.Models.RegisterResidentViewModel

@{
    ViewData["Title"] = "Register New Resident";
}

<h1>@ViewData["Title"]</h1>
<p class="text-muted">You are registering a new resident for Unit ID: @Model.UnitId in Condominium ID: @Model.CondominiumId</p>
<hr />

<div class="row">
    <div class="col-md-6">
        <form asp-action="RegisterResident" method="post">
            <div asp-validation-summary="All" class="text-danger"></div>

            @* Add hidden fields for the IDs to ensure they are posted back *@
            <input type="hidden" asp-for="UnitId" />
            <input type="hidden" asp-for="CondominiumId" />

            <div class="form-floating mb-3">
                <input asp-for="FirstName" class="form-control" />
                <label asp-for="FirstName"></label>
                <span asp-validation-for="FirstName" class="text-danger"></span>
            </div>

            <div class="form-floating mb-3">
                <input asp-for="LastName" class="form-control" />
                <label asp-for="LastName"></label>
                <span asp-validation-for="LastName" class="text-danger"></span>
            </div>

            <div class="form-floating mb-3">
                <input asp-for="Email" class="form-control" />
                <label asp-for="Email"></label>
                <span asp-validation-for="Email" class="text-danger"></span>
            </div>

            <button type="submit" class="btn btn-primary">Register Resident</button>
            <a asp-action="Details" asp-route-id="@Model.CondominiumId" class="btn btn-secondary">Cancel</a>
        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## File: CondoSphere.Web/Views/Employee/Details.cshtml
```
@model CondoSphere.Web.Models.EmployeeInterventionViewModel
@using CondoSphere.Core.Enums

@{
    ViewData["Title"] = "Task Details";
}

<h1>@Model.Occurrence.Title</h1>
<p class="text-muted">Task scheduled for @Model.Intervention.StartDate.ToLocalTime().ToString("f")</p>
<hr />

<div class="row">
    <div class="col-md-8">
        @* ===== CARD 1: THE TASK (INTERVENTION) & STATUS UPDATE FORM ===== *@
        <div class="card shadow-sm mb-4">
            <div class="card-header">
                <h5 class="mb-0">Your Assigned Task</h5>
            </div>
            <div class="card-body">
                <form asp-action="UpdateStatus" asp-route-interventionId="@Model.Intervention.Id" method="post">
                    @Html.AntiForgeryToken()
                    <dl class="row align-items-center">
                        <dt class="col-sm-3">Task Description</dt>
                        <dd class="col-sm-9">@Model.Intervention.Description</dd>

                        <dt class="col-sm-3">Update Status</dt>
                        <dd class="col-sm-9">
                            <div class="input-group" style="max-width: 300px;">
                                <select asp-for="StatusUpdate.Status" asp-items="Html.GetEnumSelectList<InterventionStatus>()" class="form-select"></select>
                                <button type="submit" class="btn btn-primary">Update Status</button>
                            </div>
                            <span asp-validation-for="StatusUpdate.Status" class="text-danger"></span>
                        </dd>
                    </dl>
                </form>
            </div>
        </div>

        @* ===== CARD 2: THE ORIGINAL PROBLEM REPORT (OCCURRENCE) ===== *@
        <div class="card shadow-sm">
            <div class="card-header">
                <h5 class="mb-0">Original Problem Report Details</h5>
            </div>
            <div class="card-body">
                <dl class="row">
                    <dt class="col-sm-3">Reported On</dt>
                    <dd class="col-sm-9">@Model.Occurrence.ReportedDate.ToLocalTime().ToString("f")</dd>

                    <dt class="col-sm-3">Reported By</dt>
                    <dd class="col-sm-9">@Model.Occurrence.ReportedByUserName</dd>
                </dl>
                <hr />
                <h5>Original Description</h5>
                <p>@Model.Occurrence.Description</p>
            </div>
        </div>

        <div class="mt-3">
            <a asp-action="Index" class="btn btn-secondary">
                <i class="bi bi-arrow-left me-1"></i> Back to My Tasks
            </a>
        </div>
    </div>
    <div class="col-md-4">
        @* ===== CARD 3: THE ATTACHED IMAGE ===== *@
        @if (!string.IsNullOrEmpty(Model.Occurrence.ImageUrl))
        {
            <div class="card shadow-sm">
                <div class="card-header">
                    Attached Image
                </div>
                <div class="card-body p-1">
                    <a href="@Model.Occurrence.ImageUrl" target="_blank" title="Click to view full size">
                        <img src="@Model.Occurrence.ImageUrl" alt="Occurrence Image" class="img-fluid rounded" />
                    </a>
                </div>
            </div>
        }
        else
        {
            <div class="card bg-light shadow-sm">
                <div class="card-body text-center text-muted">
                    <i class="bi bi-image-alt fs-1"></i>
                    <p>No image was provided.</p>
                </div>
            </div>
        }
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## File: CondoSphere.Web/Views/Employee/Index.cshtml
```
@model IEnumerable<CondoSphere.Core.DTOs.Interventions.InterventionDto>

@{
    ViewData["Title"] = "My Assigned Tasks";
}

<h1>@ViewData["Title"]</h1>
<p class="text-muted">This is a list of all maintenance interventions currently assigned to you.</p>
<hr />

<div class="card shadow-sm">
    <div class="card-body p-0">
        @if (Model.Any())
        {
            <div class="table-responsive">
                <table class="table table-hover mb-0 align-middle">
                    <thead class="table-light">
                        <tr>
                            <th>Description</th>
                            <th>Scheduled Start</th>
                            <th>Status</th>
                            <th class="text-end">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        @foreach (var intervention in Model)
                        {
                            <tr>
                                <td>@intervention.Description</td>
                                <td>@intervention.StartDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm")</td>
                                <td>
                                    @* We can add color-coding here later *@
                                    <span class="badge bg-info">@intervention.Status</span>
                                </td>
                                <td class="text-end">
                                    <a asp-action="Details" asp-route-interventionId="@intervention.Id" class="btn btn-sm btn-outline-primary">View Details</a>
                                </td>
                            </tr>
                        }
                    </tbody>
                </table>
            </div>
        }
        else
        {
            <div class="text-center p-5">
                <i class="bi bi-check2-circle fs-1 text-success"></i>
                <h4 class="mt-3">No tasks assigned!</h4>
                <p class="text-muted">You currently have no interventions assigned to you. Great job!</p>
            </div>
        }
    </div>
</div>
```

## File: CondoSphere.Web/Views/Home/Index.cshtml
```
@{
    ViewData["Title"] = "Home Page";
}

<div class="text-center">
    <h1 class="display-4">Welcome</h1>
    <p>Learn about <a href="https://learn.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
</div>
```

## File: CondoSphere.Web/Views/Home/Privacy.cshtml
```
@{
    ViewData["Title"] = "Privacy Policy";
}
<h1>@ViewData["Title"]</h1>

<p>Use this page to detail your site's privacy policy.</p>
```

## File: CondoSphere.Web/Views/Portal/CreateOccurrence.cshtml
```
@model CondoSphere.Core.DTOs.Occurrences.CreateOccurrenceDto

@{
    ViewData["Title"] = "Report New Occurrence";
}

<h1>@ViewData["Title"]</h1>
<p>Please provide a clear title, a detailed description of the issue, and an optional photo.</p>
<hr />

<div class="row">
    <div class="col-md-8">
        <form asp-action="CreateOccurrence" method="post" enctype="multipart/form-data">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <div class="form-floating mb-3">
                <input asp-for="Title" class="form-control" placeholder="e.g., Leaky faucet in kitchen" />
                <label asp-for="Title"></label>
                <span asp-validation-for="Title" class="text-danger"></span>
            </div>

            <div class="form-floating mb-3">
                <textarea asp-for="Description" class="form-control" placeholder="Describe the issue in detail..." style="height: 150px"></textarea>
                <label asp-for="Description"></label>
                <span asp-validation-for="Description" class="text-danger"></span>
            </div>

            <div class="mb-3">
                <label for="imageFile" class="form-label">Upload an Image (Optional)</label>
                <input name="imageFile" id="imageFile" class="form-control" type="file" accept="image/*" />
            </div>

            <div class="mb-3">
                <img id="imagePreview" src="#" alt="Image Preview" class="img-fluid rounded" style="display: none; max-height: 300px;" />
            </div>

            <button type="submit" class="btn btn-success">Submit Report</button>
            <a asp-action="Index" class="btn btn-secondary">Cancel</a>
        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />

    <script>
        document.addEventListener('DOMContentLoaded', function () {
            const imageFileInput = document.getElementById('imageFile');
            const imagePreview = document.getElementById('imagePreview');

            imageFileInput.addEventListener('change', function () {
                const file = this.files[0];
                if (file) {
                    const reader = new FileReader();
                    reader.onload = function (e) {
                        imagePreview.src = e.target.result;
                        imagePreview.style.display = 'block';
                    }
                    reader.readAsDataURL(file);
                } else {
                    imagePreview.src = '#';
                    imagePreview.style.display = 'none';
                }
            });
        });
    </script>
}
```

## File: CondoSphere.Web/Views/Portal/Details.cshtml
```
@model CondoSphere.Core.DTOs.Occurrences.OccurrenceDto

@{
    ViewData["Title"] = "Occurrence Details";
}

<h1>@Model.Title</h1>

<div class="row">
    <div class="col-md-8">
        <div class="card">
            <div class="card-header">
                Details
            </div>
            <div class="card-body">
                <dl class="row">
                    <dt class="col-sm-3">Status</dt>
                    <dd class="col-sm-9">
                        @{
                            var statusClass = "bg-secondary";
                            switch (Model.Status)
                            {
                                case CondoSphere.Core.Enums.OccurrenceStatus.Open:
                                    statusClass = "bg-danger";
                                    break;
                                case CondoSphere.Core.Enums.OccurrenceStatus.InProgress:
                                    statusClass = "bg-warning text-dark";
                                    break;
                                case CondoSphere.Core.Enums.OccurrenceStatus.Resolved:
                                    statusClass = "bg-info";
                                    break;
                                case CondoSphere.Core.Enums.OccurrenceStatus.Closed:
                                    statusClass = "bg-success";
                                    break;
                            }
                        }
                        <span class="badge @statusClass fs-6">@Model.Status</span>
                    </dd>

                    <dt class="col-sm-3">Reported On</dt>
                    <dd class="col-sm-9">@Model.ReportedDate.ToLocalTime().ToString("f")</dd>

                    <dt class="col-sm-3">Reported By</dt>
                    <dd class="col-sm-9">@Model.ReportedByUserName</dd>
                </dl>
                <hr />
                <h5>Description</h5>
                <p>@Model.Description</p>
            </div>
        </div>
        <div class="mt-3">
            <a asp-action="Index" class="btn btn-secondary">Back to List</a>
        </div>
    </div>
    <div class="col-md-4">
        @if (!string.IsNullOrEmpty(Model.ImageUrl))
        {
            <div class="card">
                <div class="card-header">
                    Attached Image
                </div>
                <div class="card-body p-1">
                    <img src="@Model.ImageUrl" alt="Occurrence Image" class="img-fluid rounded" />
                </div>
            </div>
        }
        else
        {
            <div class="card bg-light">
                <div class="card-body text-center text-muted">
                    <i class="bi bi-image-alt fs-1"></i>
                    <p>No image was provided.</p>
                </div>
            </div>
        }
    </div>
</div>
```

## File: CondoSphere.Web/Views/Portal/Index.cshtml
```
@model CondoSphere.Web.Models.PortalDashboardViewModel

@{
    ViewData["Title"] = "My Portal";
}

<h1>Welcome to your Resident Portal</h1>
<p class="text-muted">Here you can view documents, report issues, and manage your account.</p>
<hr />

<div class="row">
    <div class="col-md-8">
        <h4>My Reported Occurrences</h4>

        @if (Model.Occurrences.Any())
        {
            <div class="table-responsive border rounded">
                <table class="table table-hover mb-0 align-middle">
                    <thead class="table-light">
                        <tr>
                            <th scope="col">Title</th>
                            <th scope="col">Date Reported</th>
                            <th scope="col">Status</th>
                            <th scope="col" class="text-end">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        @foreach (var occurrence in Model.Occurrences)
                        {
                            <tr>
                                <td><strong>@occurrence.Title</strong></td>
                                <td>@occurrence.ReportedDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm")</td>
                                <td>
                                    @{
                                        var statusClass = "bg-secondary";
                                        switch (occurrence.Status)
                                        {
                                            case CondoSphere.Core.Enums.OccurrenceStatus.Open:
                                                statusClass = "bg-danger";
                                                break;
                                            case CondoSphere.Core.Enums.OccurrenceStatus.InProgress:
                                                statusClass = "bg-warning text-dark";
                                                break;
                                            case CondoSphere.Core.Enums.OccurrenceStatus.Resolved:
                                                statusClass = "bg-info";
                                                break;
                                            case CondoSphere.Core.Enums.OccurrenceStatus.Closed:
                                                statusClass = "bg-success";
                                                break;
                                        }
                                    }
                                    <span class="badge @statusClass">@occurrence.Status</span>
                                </td>
                                <td class="text-end">
                                    <a asp-action="Details" asp-route-id="@occurrence.Id" class="btn btn-sm btn-outline-primary">View Details</a>
                                </td>
                            </tr>
                        }
                    </tbody>
                </table>
            </div>
        }
        else
        {
            <div class="text-center p-4 border rounded">
                <p class="text-muted mb-0">You have not reported any occurrences yet.</p>
            </div>
        }
    </div>
    <div class="col-md-4">
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Have an issue?</h5>
                <p class="card-text">Report a maintenance issue or other problem in your unit or common areas.</p>
                <a asp-action="CreateOccurrence" class="btn btn-primary w-100">
                    <i class="bi bi-flag-fill me-1"></i> Report New Occurrence
                </a>
            </div>
        </div>
    </div>
</div>
```

## File: CondoSphere.Web/Views/Profile/ChangePassword.cshtml
```
@model ChangePasswordViewModel
@{
    ViewData["Title"] = "Change Password";
}

<div class="row justify-content-center">
    <div class="col-lg-6">
        <div class="card shadow-lg border-0 mt-4">
            <div class="card-header bg-secondary text-white py-3">
                <h2 class="mb-0 text-center"><i class="bi bi-shield-lock me-2"></i>@ViewData["Title"]</h2>
            </div>
            <div class="card-body p-4">
                <form asp-action="ChangePassword" method="post">
                    <div asp-validation-summary="All" class="text-danger"></div>
                    <div class="form-floating mb-3">
                        <input asp-for="CurrentPassword" class="form-control" type="password" />
                        <label asp-for="CurrentPassword"></label>
                        <span asp-validation-for="CurrentPassword" class="text-danger"></span>
                    </div>
                    <div class="form-floating mb-3">
                        <input asp-for="NewPassword" class="form-control" type="password" />
                        <label asp-for="NewPassword"></label>
                        <span asp-validation-for="NewPassword" class="text-danger"></span>
                    </div>
                    <div class="form-floating mb-3">
                        <input asp-for="ConfirmPassword" class="form-control" type="password" />
                        <label asp-for="ConfirmPassword"></label>
                        <span asp-validation-for="ConfirmPassword" class="text-danger"></span>
                    </div>
                    <button type="submit" class="w-100 btn btn-primary">Update Password</button>
                    <div class="text-center mt-3">
                        <a asp-controller="Profile" asp-action="Index">Cancel</a>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>
```

## File: CondoSphere.Web/Views/Profile/Index.cshtml
```
@model MyProfileViewModel
@{
    ViewData["Title"] = "My Profile";
}

<div class="row justify-content-center">
    <div class="col-lg-8">
        <div class="card shadow-lg border-0 mt-4">
            <div class="card-header bg-primary text-white py-3">
                <h2 class="mb-0 text-center"><i class="bi bi-person-gear me-2"></i>@ViewData["Title"]</h2>
            </div>
            <div class="card-body p-4 p-md-5">
                <form method="post" enctype="multipart/form-data" id="profileForm">
                    <input type="hidden" asp-for="CurrentProfileImageUrl" />
                    <div asp-validation-summary="All" class="text-danger"></div>
                    <div asp-validation-summary="All" class="text-danger"></div>

                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label asp-for="FirstName" class="form-label"></label>
                            <input asp-for="FirstName" class="form-control" />
                            <span asp-validation-for="FirstName" class="text-danger small"></span>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label asp-for="LastName" class="form-label"></label>
                            <input asp-for="LastName" class="form-control" />
                            <span asp-validation-for="LastName" class="text-danger small"></span>
                        </div>
                    </div>

                    <hr class="my-4" />

                    <div class="row align-items-center">
                        <div class="col-md-4 text-center">
                            <img src="@(Model.CurrentProfileImageUrl ?? "/images/user-photos/default-profile.png")"
                                 alt="Current Profile Image" class="img-thumbnail rounded-circle mb-2"
                                 style="width: 150px; height: 150px; object-fit: cover;" />
                            <small class="text-muted d-block">Current Image</small>
                        </div>
                        <div class="col-md-8">
                            <label asp-for="ProfileImage" class="form-label"></label>
                            <input asp-for="ProfileImage" class="form-control" type="file" accept="image/*" />
                            <span asp-validation-for="ProfileImage" class="text-danger small"></span>
                        </div>
                    </div>
                </form>
            </div>
            <div class="card-footer bg-light p-3">
                <div class="d-flex justify-content-end align-items-center gap-2">
                    <a asp-controller="Profile" asp-action="ChangePassword" class="btn btn-secondary">Change Password</a>
                    <button type="submit" form="profileForm" class="btn btn-primary">Save Changes</button>
                </div>
            </div>
        </div>
    </div>
</div>
```

## File: CondoSphere.Web/Views/Shared/_Layout.cshtml
```
@using CondoSphere.Core
@using Microsoft.AspNetCore.Identity

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"] - CondoSphere</title>
    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="~/css/site.css" asp-append-version="true" />
    <link rel="stylesheet" href="~/CondoSphere.Web.styles.css" asp-append-version="true" />
    @* Added reference for Bootstrap Icons used in some views *@
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
</head>
<body>
    <header>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            <div class="container-fluid">
                <a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">CondoSphere</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
                        </li>

                        @* ===== START OF ROLE-AWARE NAVIGATION ===== *@
                        @if (User.Identity != null && User.Identity.IsAuthenticated)
                        {
                            if (User.IsInRole(RoleConstants.CompanyAdmin))
                            {
                                <li class="nav-item">
                                    <a class="nav-link text-dark" asp-controller="Administration" asp-action="Index">Admin Dashboard</a>
                                </li>
                            }
                            if (User.IsInRole(RoleConstants.CondoManager))
                            {
                                <li class="nav-item">
                                    <a class="nav-link text-dark" asp-controller="CondoManagement" asp-action="Index">My Condos</a>
                                </li>
                            }
                            if (User.IsInRole(RoleConstants.CondoResident))
                            {
                                <li class="nav-item">
                                    @* This is a placeholder for a future feature *@
                                    <a class="nav-link text-dark" asp-controller="Portal" asp-action="Index">My Portal</a>
                                </li>
                            }
                            if(User.IsInRole(RoleConstants.Employee))
                            {
                                <li class="nav-item">
                                    <a class="nav-link text-dark" asp-controller="Employee" asp-action="Index">My Tasks</a>
                                </li>
                            }
                        }
                        @* ===== END OF ROLE-AWARE NAVIGATION ===== *@

                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
                        </li>
                    </ul>

                    <partial name="_LoginPartial" />

                </div>
            </div>
        </nav>
    </header>
    <div class="container">
        <main role="main" class="pb-3">
            @if (TempData["SuccessMessage"] != null)
            {
                <div class="alert alert-success alert-dismissible fade show" role="alert">
                    @TempData["SuccessMessage"]
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
            }
            @if (TempData["ErrorMessage"] != null)
            {
                <div class="alert alert-danger alert-dismissible fade show" role="alert">
                    @TempData["ErrorMessage"]
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
            }

            @RenderBody()
        </main>
    </div>

    <footer class="border-top footer text-muted">
        <div class="container">
            © 2025 - CondoSphere - <a asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
        </div>
    </footer>
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="~/js/site.js" asp-append-version="true"></script>
    @await RenderSectionAsync("Scripts", required: false)
</body>
</html>
```

## File: CondoSphere.Web/Views/Shared/_Layout.cshtml.css
```css
/* Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
for details on configuring this project to bundle and minify static web assets. */

a.navbar-brand {
  white-space: normal;
  text-align: center;
  word-break: break-all;
}

a {
  color: #0077cc;
}

.btn-primary {
  color: #fff;
  background-color: #1b6ec2;
  border-color: #1861ac;
}

.nav-pills .nav-link.active, .nav-pills .show > .nav-link {
  color: #fff;
  background-color: #1b6ec2;
  border-color: #1861ac;
}

.border-top {
  border-top: 1px solid #e5e5e5;
}
.border-bottom {
  border-bottom: 1px solid #e5e5e5;
}

.box-shadow {
  box-shadow: 0 .25rem .75rem rgba(0, 0, 0, .05);
}

button.accept-policy {
  font-size: 1rem;
  line-height: inherit;
}

.footer {
  position: absolute;
  bottom: 0;
  width: 100%;
  white-space: nowrap;
  line-height: 60px;
}
```

## File: CondoSphere.Web/Views/Shared/_LoginPartial.cshtml
```
@using System.Security.Claims

<ul class="navbar-nav">
    @if (User.Identity?.IsAuthenticated == true)
    {
        <li class="nav-item">
            <a class="nav-link text-dark d-flex align-items-center" asp-controller="Profile" asp-action="Index" title="Manage Your Account">

                @{
                    var profilePictureUrl = User.FindFirstValue("profile_picture");
                }

                <img src="@(string.IsNullOrEmpty(profilePictureUrl) ? "/images/user-photos/default-profile.png" : profilePictureUrl)"
                     alt="Profile Picture"
                     class="rounded-circle"
                     style="width: 30px; height: 30px; object-fit: cover; margin-right: 8px;" />

                Hello, @User.Identity.Name!
            </a>
        </li>
        <li class="nav-item">
            <form class="form-inline" asp-controller="Account" asp-action="Logout" method="post">
                @Html.AntiForgeryToken()
                <button type="submit" class="nav-link btn btn-link text-dark">Logout</button>
            </form>
        </li>
    }
    else
    {
        <li class="nav-item">
            <a class="nav-link text-dark" asp-controller="Account" asp-action="Register">Register</a>
        </li>
        <li class="nav-item">
            <a class="nav-link text-dark" asp-controller="Account" asp-action="Login">Login</a>
        </li>
    }
</ul>
```

## File: CondoSphere.Web/Views/Shared/_ValidationScriptsPartial.cshtml
```
<script src="~/lib/jquery-validation/dist/jquery.validate.min.js"></script>
<script src="~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js"></script>
```

## File: CondoSphere.Web/Views/Shared/Error.cshtml
```
@model ErrorViewModel
@{
    ViewData["Title"] = "Error";
}

<h1 class="text-danger">Error.</h1>
<h2 class="text-danger">An error occurred while processing your request.</h2>

@if (Model.ShowRequestId)
{
    <p>
        <strong>Request ID:</strong> <code>@Model.RequestId</code>
    </p>
}

<h3>Development Mode</h3>
<p>
    Swapping to <strong>Development</strong> environment will display more detailed information about the error that occurred.
</p>
<p>
    <strong>The Development environment shouldn't be enabled for deployed applications.</strong>
    It can result in displaying sensitive information from exceptions to end users.
    For local debugging, enable the <strong>Development</strong> environment by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>
    and restarting the app.
</p>
```

## File: CondoSphere.Web/wwwroot/css/site.css
```css
html {
  font-size: 14px;
}

@media (min-width: 768px) {
  html {
    font-size: 16px;
  }
}

.btn:focus, .btn:active:focus, .btn-link.nav-link:focus, .form-control:focus, .form-check-input:focus {
  box-shadow: 0 0 0 0.1rem white, 0 0 0 0.25rem #258cfb;
}

html {
  position: relative;
  min-height: 100%;
}

body {
  margin-bottom: 60px;
}
```

## File: CondoSphere.Web/wwwroot/js/site.js
```javascript
// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
```
