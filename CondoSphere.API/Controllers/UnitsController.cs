using CondoSphere.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/condominiums/{condominiumId}/[controller]")]
    public class UnitsController : ControllerBase
    {
        // This endpoint can only be accessed by a user who is a CondoManager AND
        // satisfies the "IsCondoManagerPolicy", which checks if they manage this specific condominiumId.
        [HttpGet]
        [Authorize(Roles = nameof(SystemRole.CondoManager), Policy = "IsCondoManagerPolicy")]
        public IActionResult GetUnitsForCondominium(int condominiumId)
        {
            // If the code reaches here, the user is authorized.
            return Ok($"Successfully accessed units for condominium {condominiumId}.");
        }
    }
}