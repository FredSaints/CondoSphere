using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Assembly;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Assemblies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // roles específicos em cada ação
    public class AssembliesController : ControllerBase
    {
        private readonly IAssemblyService _svc;
        private readonly ICurrentUserService _current;
        public AssembliesController(IAssemblyService svc, ICurrentUserService current)
        {
            _svc = svc; _current = current;
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConstants.CompanyAdmin},{RoleConstants.CondoManager}")]
        public async Task<ActionResult<AssemblyDto>> Create(CreateAssemblyDto dto)
        {
            var res = await _svc.CreateAsync(dto);
            if (res == null) return Forbid();
            return CreatedAtAction(nameof(GetForCondominium), new { condominiumId = res.CondominiumId }, res);
        }

        [HttpGet("condominium/{condominiumId:int}")]
        public async Task<ActionResult<IEnumerable<AssemblyDto>>> GetForCondominium(int condominiumId)
            => Ok(await _svc.GetForCondominiumAsync(condominiumId));

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
            var sent = await _svc.SendInvitesAsync(assemblyId, dto);
            return Ok(new { sent });
        }

        [HttpGet("{assemblyId:int}/messages")]
        public async Task<ActionResult<IEnumerable<AssemblyMessageDto>>> GetMessages(int assemblyId)
            => Ok(await _svc.GetMessagesAsync(assemblyId));

        [HttpPost("{assemblyId:int}/messages")]
        public async Task<ActionResult<AssemblyMessageDto>> PostMessage(int assemblyId, PostAssemblyMessageDto dto)
        {
            var msg = await _svc.PostMessageAsync(assemblyId, dto);
            if (msg == null) return Forbid();
            return Ok(msg);
        }
    }
}
