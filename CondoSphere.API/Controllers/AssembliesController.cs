using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Assembly;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Assemblies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // roles específicos em cada ação    public class AssembliesController : ControllerBase
    {
        private readonly IAssemblyService _svc;
        private readonly ICurrentUserService _current;
        private readonly IHubContext<CondoSphere.Shared.Hubs.AssemblyChatHub> _hub;
        public AssembliesController(
         IAssemblyService svc,
         ICurrentUserService current,
         IHubContext<CondoSphere.Shared.Hubs.AssemblyChatHub> hub)
        {
            _svc = svc;
            _current = current;
            _hub = hub;
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConstants.CompanyAdmin},{RoleConstants.CondoManager}")]        public async Task<ActionResult<AssemblyDto>> Create([FromBody] CreateAssemblyDto dto)
        {
            var created = await _svc.CreateAsync(dto);
            if (created == null) return Forbid();
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet("condominium/{condominiumId:int}")]
        public async Task<ActionResult<IEnumerable<AssemblyDto>>> GetForCondominium(int condominiumId)
        {
            var list = await _svc.GetByCondominiumAsync(condominiumId);
            return Ok(list);
        }
        
        [HttpGet("{id:int}")]
/// <summary>
/// Handles the Get By Id action.
/// </summary>
public async Task<ActionResult<AssemblyDto>> GetById(int id)
        {
            var dto = await _svc.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return Ok(dto);
        }



        [HttpGet("company")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<ActionResult<IEnumerable<AssemblyDto>>> GetAllForCompany([FromServices] ILogger<AssembliesController> log)
        {
            if (_current.CompanyId is null) return Unauthorized();
            try
            {
                var list = await _svc.GetAllForCompanyAsync(_current.CompanyId.Value);
                return Ok(list);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Erro ao listar assembleias da empresa {CompanyId}", _current.CompanyId);
                return Problem(detail: ex.Message, statusCode: 500);
            }
        }


        [HttpPost("{assemblyId:int}/invites")]
        [Authorize(Roles = $"{RoleConstants.CompanyAdmin},{RoleConstants.CondoManager}")]
        public async Task<ActionResult> SendInvites(int assemblyId, SendAssemblyInvitesDto dto)
        {
            if (await IsExpiredAsync(assemblyId)) return Forbid(); // ou return BadRequest("Meeting ended");
            var sent = await _svc.SendInvitesAsync(assemblyId, dto);
            return Ok(new { sent });
        }

        [HttpGet("{assemblyId:int}/room-info")]
/// <summary>
/// Handles the Get Room Info action.
/// </summary>
public async Task<ActionResult<AssemblyRoomInfoDto>> GetRoomInfo(int assemblyId)
        {
            if (await IsExpiredAsync(assemblyId)) return Forbid();
            var info = await _svc.GetRoomInfoAsync(assemblyId);
            return info is null ? Forbid() : Ok(info);
        }
        private async Task<bool> IsExpiredAsync(int assemblyId)
        {
            var dto = await _svc.GetByIdAsync(assemblyId);
            if (dto == null) return true;             
                                               
            return dto.Date <= DateTime.UtcNow;
        }
    }
}
