using CondoSphere.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/me")]
[Authorize]public class MeController : ControllerBase
{
    private readonly ICurrentUserService _current;  
    private readonly IUnitOfWork _uow;

    public MeController(ICurrentUserService current, IUnitOfWork uow)  
    {
        _current = current;
        _uow = uow;
    }

    // devolve o condomínio “principal”/associado do utilizador atual
    [HttpGet("condominium-id")]    public async Task<ActionResult<IdDto>> GetMyCondominiumId()
    {
        if (_current.UserId == null) return Unauthorized();

        // Ajusta isto à tua lógica real para obter o condomínio do user:
        // ex.: pela unidade onde ele é residente/funcionário/gestor
        var condoId = await _uow.Users.GetPrimaryCondominiumIdAsync(_current.UserId.Value);
        if (condoId == 0) return NotFound();

        return Ok(new IdDto { Id = condoId });
    }
}

public sealed class IdDto
{
    public int Id { get; set; }
}
