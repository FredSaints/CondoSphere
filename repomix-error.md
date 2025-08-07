This file is a merged representation of a subset of the codebase, containing specifically included files, combined into a single document by Repomix.

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
- Only files matching these patterns are included: CondoSphere.Web/Views/Profile/Index.cshtml, CondoSphere.Web/Controllers/ProfileController.cs, CondoSphere.Web/Services/ImageService.cs, CondoSphere.Web/Services/ApiClient.cs, CondoSphere.API/Controllers/ProfileController.cs, CondoSphere.Application/Services/User/UserService.cs, CondoSphere.Web/Models/MyProfileViewModel.cs, CondoSphere.Core/DTOs/Account/UpdateProfileDto.cs
- Files matching patterns in .gitignore are excluded
- Files matching default ignore patterns are excluded
- Files are sorted by Git change count (files with more changes are at the bottom)

# Directory Structure
```
CondoSphere.API/Controllers/ProfileController.cs
CondoSphere.Application/Services/User/UserService.cs
CondoSphere.Core/DTOs/Account/UpdateProfileDto.cs
CondoSphere.Web/Controllers/ProfileController.cs
CondoSphere.Web/Models/MyProfileViewModel.cs
CondoSphere.Web/Services/ApiClient.cs
CondoSphere.Web/Services/ImageService.cs
CondoSphere.Web/Views/Profile/Index.cshtml
```

# Files

## File: CondoSphere.API/Controllers/ProfileController.cs
```csharp
using CondoSphere.Application.Interfaces;
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

        public ProfileController(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }

        [HttpPut] // This endpoint now only accepts JSON.
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto dto)
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var (success, errors) = await _userService.UpdateProfileAsync(userId.Value, dto);

            if (success) return Ok(new { message = "Profile updated successfully." });
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

## File: CondoSphere.Web/Controllers/ProfileController.cs
```csharp
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CondoSphere.Web.Controllers
{
    [Authorize]
    [Route("profile")]
    public class ProfileController : Controller
    {
        private readonly ApiClient _apiClient;
        private readonly IImageService _imageService;

        public ProfileController(ApiClient apiClient, IImageService imageService)
        {
            _apiClient = apiClient;
            _imageService = imageService;
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
                return View(model);
            }

            // This part remains the same: save the image and update the database via the API.
            string? newImageUrl = model.CurrentProfileImageUrl;
            if (model.ProfileImage != null && model.ProfileImage.Length > 0)
            {
                newImageUrl = await _imageService.SaveImageAsync(model.ProfileImage, "user-photos", model.CurrentProfileImageUrl);
            }
            var dto = new UpdateProfileDto
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfilePictureUrl = newImageUrl
            };
            var (success, message) = await _apiClient.UpdateProfileAsync(dto);

            if (success)
            {
                // ===== THIS IS THE NEW SESSION REFRESH LOGIC =====

                // 1. Fetch the user's complete, updated profile from the API.
                var updatedProfile = await _apiClient.GetMyProfileAsync();
                if (updatedProfile != null)
                {
                    // 2. Create a new set of claims based on the fresh data.
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, updatedProfile.Id.ToString()),
                new Claim(ClaimTypes.Name, updatedProfile.Email),
                new Claim(ClaimTypes.Email, updatedProfile.Email),
                new Claim(ClaimTypes.GivenName, updatedProfile.FirstName),
                new Claim(ClaimTypes.Surname, updatedProfile.LastName),
                new Claim("profile_picture", updatedProfile.ProfilePictureUrl ?? "")
            };
                    foreach (var role in updatedProfile.Roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties { IsPersistent = true };

                    // 3. Sign the user in again. This replaces their old cookie with the new one.
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                }

                TempData["SuccessMessage"] = "Your profile has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, message);
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
    }
}
```

## File: CondoSphere.Web/Services/ApiClient.cs
```csharp
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
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

        public async Task<OccurrenceDto?> CreateOccurrenceAsync(CreateOccurrenceDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/occurrences", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<OccurrenceDto>();
            }
            return null;
        }

        public async Task<(bool Success, string Message)> ForgotPasswordAsync(string email)
        {
            var requestDto = new ForgotPasswordDto { Email = email };
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/forgot-password", requestDto);
            var message = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, message);
        }

        public async Task<(bool Success, string Message)> UpdateProfileAsync(UpdateProfileDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/profile", dto);
            var message = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, message);
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
    }
}
```
