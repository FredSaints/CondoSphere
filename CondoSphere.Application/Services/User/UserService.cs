using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Token;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.Entities.Users;
using CondoSphere.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.Design;
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
        private readonly ISmsService _smsService;
        private readonly IPhoneNumberService _phoneNumberService;


        public UserService(
            UserManager<CoreUser> userManager,
            IUnitOfWork unitOfWork,
            ITokenService tokenService,
            IMailService mailService,
            IConfiguration configuration,
            ICurrentUserService currentUserService, 
            ISmsService smsService, 
            IPhoneNumberService phoneNumberService)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _mailService = mailService;
            _configuration = configuration;
            _currentUserService = currentUserService;
            _smsService = smsService;
            _phoneNumberService = phoneNumberService;
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
            if (!string.Equals(user.PhoneNumber, dto.PhoneNumber, StringComparison.Ordinal))
            {
                var phoneRes = await _userManager.SetPhoneNumberAsync(user, dto.PhoneNumber);
                if (!phoneRes.Succeeded)
                    return (false, phoneRes.Errors);
            }
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
                PhoneNumber = user.PhoneNumber,
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

        public async Task<CoreUser?> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> IsEmailConfirmedAsync(CoreUser user)
        {
            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<IdentityResult> ResendConfirmationEmailAsync(EmailDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = WebUtility.UrlEncode(token);
            var webAppBaseUrl = _configuration["ClientSettings:WebAppBaseUrl"];
            var confirmationLink = $"{webAppBaseUrl}/Account/ConfirmEmail?userId={user.Id}&token={encodedToken}";

            await _mailService.SendEmailAsync(
                user.Email,
                "Confirm your CondoSphere Account",
                $"<h1>Welcome to CondoSphere!</h1><p>Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.</p>");

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> Switch2SVAsync(string email, bool enable2SV)
        {
            var  user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            user.TwoFactorEnabled = enable2SV;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return result;
            }

            return IdentityResult.Success;

        }

        public async Task<IdentityResult> SendCode2SVAsync(string email, TwoFactorMethod twoFactorMethodOption)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            if (!user.TwoFactorEnabled) return IdentityResult.Failed(new IdentityError { Description = "Two-factor auth is disabled for this user." });

            var provider = twoFactorMethodOption == TwoFactorMethod.Email
                ? TokenOptions.DefaultEmailProvider   // "Email"
                : TokenOptions.DefaultPhoneProvider;  // "Phone"

            // Pré-condições de contacto
            if (twoFactorMethodOption == TwoFactorMethod.Email)
            {
                if (string.IsNullOrWhiteSpace(user.Email))
                    return IdentityResult.Failed(new IdentityError { Description = "User has no email." });
                // opcional: exigir EmailConfirmed
            }
            else
            {
                if (string.IsNullOrWhiteSpace(user.PhoneNumber))
                    return IdentityResult.Failed(new IdentityError { Description = "User has no phone number." });
                // opcional: exigir PhoneNumberConfirmed
            }

        
            var code = await _userManager.GenerateTwoFactorTokenAsync(user, provider);

            if (twoFactorMethodOption == TwoFactorMethod.Email)
            {
                await _mailService.SendEmailAsync(
                    user.Email!,
                    "Your login code",
                    $"<p>Hello {user.FirstName},</p><p>Your 2FA code is: <b>{code}</b></p><p>This code expires shortly.</p>");
            }
            else
            {
          
                var to = _phoneNumberService.Normalize(user.PhoneNumber);
                var (ok, err) = await _smsService.SendSmsAsync(to, $"Your 2FA code: {code}");

                if (!ok)
                {
                    return IdentityResult.Failed(new IdentityError { Description = $"SMS failed: {err}" });
                }
            }


            return IdentityResult.Success;
        }

        public async Task<(bool Succeeded, string? Token, string? Error)> VerifyCode2SVAsync(string email, TwoFactorMethod method, string code)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return (false, null, "User not found.");
            if (!user.TwoFactorEnabled) return (false, null, "Two-factor auth is disabled.");

            var provider = method == TwoFactorMethod.Email
                ? TokenOptions.DefaultEmailProvider
                : TokenOptions.DefaultPhoneProvider;

            var ok = await _userManager.VerifyTwoFactorTokenAsync(user, provider, code);
            if (!ok) return (false, null, "Invalid or expired code.");

            var jwt = await _tokenService.CreateToken(user); // já existe no teu projeto
            return (true, jwt, null);
        }

        public async Task<bool> Is2SVEnabledAsync(EmailDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user.TwoFactorEnabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}