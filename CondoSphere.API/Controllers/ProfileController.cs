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