using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Token;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.Entities.Users;
using CondoSphere.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Web;


// Define a clear alias for our User entity to prevent naming collisions.
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.User
{
    /// <summary>
    /// Implements the business logic for user management.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly UserManager<CoreUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;

        public UserService(
            UserManager<CoreUser> userManager,
            IUnitOfWork unitOfWork,
            ITokenService tokenService,
            IMailService mailService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _mailService = mailService;
            _configuration = configuration;
        }

        public async Task<UserDto?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            // Check if user exists and if the provided password is correct.
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return null; // Return null to indicate a failed login attempt.
            }

            // If login is successful, create a DTO containing user info and a JWT.
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

            // Start a transaction using our Unit of Work
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var newCompany = new Company
                {
                    Name = registerDto.CompanyName,
                    IsActive = true
                };
                await _unitOfWork.Companies.AddAsync(newCompany);
                // We call CompleteAsync here, but the change is not permanent yet
                // because it's part of the transaction. We need the ID for the next step.
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
                    // If user creation fails, roll back everything.
                    await _unitOfWork.RollbackAsync();
                    return result;
                }

                await _userManager.AddToRoleAsync(newUser, SystemRole.CompanyAdmin.ToString());

                // Generate email confirmation token and send confirmation email.
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                var encodedToken = HttpUtility.UrlEncode(token);
                var webAppBaseUrl = _configuration["ClientSettings:WebAppBaseUrl"];
                var confirmationLink = $"{webAppBaseUrl}/Account/ConfirmEmail?userId={newUser.Id}&token={encodedToken}";

                await _mailService.SendEmailAsync(
                    newUser.Email,
                    "Confirm your CondoSphere Account",
                    $"<h1>Welcome to CondoSphere!</h1><p>Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.</p>");

                // If everything succeeded, commit the transaction to make all changes permanent.
                await _unitOfWork.CommitAsync();

                return IdentityResult.Success;
            }
            catch
            {
                // If any unexpected error happens, roll back everything.
                await _unitOfWork.RollbackAsync();
                throw; // Rethrow the exception to be handled by global error handling.
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
                IsActive = true
            };

            var result = await _userManager.CreateAsync(newUser, registerDto.Password);

            if (!result.Succeeded)
            {
                return result;
            }

            await _userManager.AddToRoleAsync(newUser, SystemRole.CondoManager.ToString());

            return IdentityResult.Success;
        }
    }
}