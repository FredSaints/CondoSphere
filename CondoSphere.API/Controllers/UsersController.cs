using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Document;
using CondoSphere.Application.Services.Financials;
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
        private readonly IFinancialService _financialService;
        private readonly IDocumentService _documentService;

        public UsersController(
            IUnitRepository unitRepository,
            ICurrentUserService currentUserService,
            AutoMapper.IMapper mapper,
            IFinancialService financialService,
            IDocumentService documentService)
        {
            _unitRepository = unitRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
            _financialService = financialService;
            _documentService = documentService;
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

        [HttpGet("my-quotas")]
        public async Task<IActionResult> GetMyQuotas()
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var quotas = await _financialService.GetQuotasForUserAsync(userId.Value);
            return Ok(quotas);
        }

        [HttpGet("my-documents")]
        public async Task<IActionResult> GetMyDocuments()
        {
            var userId = _currentUserService.UserId;
            if (userId == null) return Unauthorized();

            var documents = await _documentService.GetDocumentsForUserAsync(userId.Value);
            return Ok(documents);
        }
    }
}