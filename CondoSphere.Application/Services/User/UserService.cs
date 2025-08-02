using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Token;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.Entities.Users;
using Microsoft.AspNetCore.Identity;
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
        private readonly IUserRepository _userRepository;
        private readonly IUnitRepository _unitRepository; // Dependency for resident registration

        public UserService(
            UserManager<CoreUser> userManager,
            IUnitOfWork unitOfWork,
            ITokenService tokenService,
            IMailService mailService,
            IConfiguration configuration,
            IUserRepository userRepository,
            IUnitRepository unitRepository) // Inject the new dependency
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _mailService = mailService;
            _configuration = configuration;
            _userRepository = userRepository;
            _unitRepository = unitRepository; // Assign the new dependency
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

            await _unitOfWork.BeginTransactionAsync();
            try
            {
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
                    await _unitOfWork.RollbackAsync();
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

                await _unitOfWork.CommitAsync();

                return IdentityResult.Success;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
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
                EmailConfirmed = false // Email is not confirmed until they set the password
            };

            var result = await _userManager.CreateAsync(newUser); // Create user without password
            if (!result.Succeeded)
            {
                return result;
            }

            await _userManager.AddToRoleAsync(newUser, RoleConstants.CondoManager);

            // Generate and send the "Set Password" link
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
            return await _userRepository.GetCompanyUsersWithRolesAsync(companyId);
        }

        public async Task<IdentityResult> RegisterResidentAsync(RegisterResidentDto dto, int companyId, int condominiumId)
        {
            // 1. Validate that the Unit exists, belongs to the correct condominium, and is available
            var unit = await _unitRepository.GetByIdAsync(dto.UnitId);
            if (unit == null || unit.CondominiumId != condominiumId)
            {
                return IdentityResult.Failed(new IdentityError { Code = "UnitNotFound", Description = "Unit not found in this condominium." });
            }

            if (unit.ResidentId.HasValue)
            {
                return IdentityResult.Failed(new IdentityError { Code = "UnitOccupied", Description = "This unit already has an assigned resident." });
            }

            // 2. Check if user email already exists
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Code = "DuplicateEmail", Description = "An account with this email address already exists." });
            }

            // 3. Create the new user WITHOUT a password.
            // The account is created but is effectively 'locked' until a password is set.
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

            var result = await _userManager.CreateAsync(newUser); // This overload does not require a password.
            if (!result.Succeeded)
            {
                return result;
            }

            // 4. Assign the correct role
            await _userManager.AddToRoleAsync(newUser, RoleConstants.CondoResident);

            // 5. Link the new user to the unit and save
            unit.ResidentId = newUser.Id;
            _unitRepository.Update(unit);
            await _unitRepository.SaveChangesAsync();

            // 6. Generate a "Set Password" token and send the welcome email
            var token = await _userManager.GeneratePasswordResetTokenAsync(newUser);
            var encodedToken = WebUtility.UrlEncode(token);

            // This URL will point to a new page we need to create in the Web project
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
            return await _userRepository.GetUsersInRoleAsync(RoleConstants.CondoManager, companyId);
        }
    }
}