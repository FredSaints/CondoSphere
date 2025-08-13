using CondoSphere.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUnitRepository _unitRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly AutoMapper.IMapper _mapper;

        public UsersController(IUnitRepository unitRepository, ICurrentUserService currentUserService, AutoMapper.IMapper mapper)
        {
            _unitRepository = unitRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        [HttpGet("my-units")]
        public async Task<IActionResult> GetMyUnits()
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var units = await _unitRepository.GetByResidentIdAsync(userId.Value);
            var unitDtos = _mapper.Map<IEnumerable<Core.DTOs.Condominiums.UnitDto>>(units);
            return Ok(unitDtos);
        }
    }
}