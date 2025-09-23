using CondoSphere.Core;
using CondoSphere.Core.DTOs.Assemblies;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CondoSphere.Web.Controllers
{
    [Authorize]
    public class AssembliesController : Controller
    {
        private readonly ApiClient _apiClient;
        public AssembliesController(ApiClient apiClient) => _apiClient = apiClient;


        [HttpGet("/assemblies")]
        [Authorize]
        public async Task<IActionResult> Unified(int? condominiumId)
        {
            IEnumerable<AssemblyDto> list = Enumerable.Empty<AssemblyDto>();

            if (User.IsInRole(RoleConstants.CompanyAdmin))
            {
                // Admin: todas as assembleias da empresa
                list = await _apiClient.GetCompanyAssembliesAsync();
                ViewData["CondominiumId"] = 0;
            }
            else if (User.IsInRole(RoleConstants.CondoManager))
            {
                // tenta usar o último condomínio visitado (cookie) se não veio na query
                if (!condominiumId.HasValue || condominiumId.Value <= 0)
                {
                    if (Request.Cookies.TryGetValue("lastCondoId", out var lastStr) && int.TryParse(lastStr, out var lastId) && lastId > 0)
                    {
                        condominiumId = lastId;
                    }
                }

                if (condominiumId.HasValue && condominiumId.Value > 0)
                {
                    // Manager filtrado por um condomínio específico
                    list = await _apiClient.GetCondominiumAssembliesAsync(condominiumId.Value);
                    ViewData["CondominiumId"] = condominiumId.Value;

                    // lembra o último condomínio (para a navbar)
                    Response.Cookies.Append("lastCondoId", condominiumId.Value.ToString(),
                        new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(7) });
                }
                else
                {
                    // Manager sem filtro → carregar TODOS os condomínios que ele gere e agregar
                    var myCondominiums = await _apiClient.GetManagedCondominiumsAsync();
                    ViewBag.ManagedCondominiums = myCondominiums; // (opcional) para dropdown na view

                    if (myCondominiums.Count == 1)
                    {
                        // se só gere 1, redireciona para esse para habilitar "New Assembly"
                        return RedirectToAction(nameof(Unified), new { condominiumId = myCondominiums[0].Id });
                    }

                    var tasks = myCondominiums.Select(c => _apiClient.GetCondominiumAssembliesAsync(c.Id));
                    var results = await Task.WhenAll(tasks);
                    list = results.SelectMany(x => x);

                    ViewData["CondominiumId"] = 0; // 0 = “todos”
                }
            }
            else
            {
                return Forbid();
            }

            // ordenar por data desc.
            var ordered = list.OrderByDescending(a => a.Date);

            return View("UnifiedList", ordered);
        }




        // ===== MANAGER: criar =====
        [HttpGet("condo-management/{condominiumId:int}/assemblies/create")]
        [Authorize(Roles = RoleConstants.CondoManager)]
        public IActionResult Create(int condominiumId)
        {
            return View(new CreateAssemblyDto
            {
                CondominiumId = condominiumId,
                Date = DateTime.Now.AddDays(1)
            });
        }

        [HttpPost("condo-management/{condominiumId:int}/assemblies/create")]
        [Authorize(Roles = RoleConstants.CondoManager)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int condominiumId, CreateAssemblyDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            dto.CondominiumId = condominiumId;

            var created = await _apiClient.CreateAssemblyAsync(dto);
            TempData[created is null ? "ErrorMessage" : "SuccessMessage"] =
                created is null ? "Falha ao criar a assembleia." : "Assembleia criada com sucesso.";
            return RedirectToAction(nameof(Index), new { condominiumId });
        }

        [HttpGet("/condo-management/{condominiumId:int}/assemblies/{assemblyId:int}/invite")]
        [Authorize(Roles = RoleConstants.CondoManager)]
        public async Task<IActionResult> Invite(int condominiumId, int assemblyId)
        {
            var residents = await _apiClient.GetCondominiumResidentsAsync(condominiumId);

            ViewData["CondominiumId"] = condominiumId;
            ViewData["AssemblyId"] = assemblyId;

            // lista para a combo (value = Id, text = "Nome — email / phone")
            ViewBag.Residents = residents
                .Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = $"{r.FullName}" +
                           $"{(string.IsNullOrWhiteSpace(r.Email) ? "" : $" — {r.Email}")}" +
                           $"{(string.IsNullOrWhiteSpace(r.Phone) ? "" : $" / {r.Phone}")}"
                })
                .ToList();

            return View(new SendAssemblyInvitesDto());
        }

        [HttpPost("/condo-management/{condominiumId:int}/assemblies/{assemblyId:int}/invite")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleConstants.CondoManager)]
        public async Task<IActionResult> Invite(int condominiumId, int assemblyId, SendAssemblyInvitesDto dto)
        {
            if (!dto.InviteAllResidents && (dto.SelectedResidentIds == null || dto.SelectedResidentIds.Count == 0))
            {
                ModelState.AddModelError("", "Seleciona pelo menos um morador ou ativa 'Invite all residents'.");
            }

            if (!ModelState.IsValid)
            {
                // recompor a combo
                var residents = await _apiClient.GetCondominiumResidentsAsync(condominiumId);
                ViewBag.Residents = residents.Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = $"{r.FullName}" +
                           $"{(string.IsNullOrWhiteSpace(r.Email) ? "" : $" — {r.Email}")}" +
                           $"{(string.IsNullOrWhiteSpace(r.Phone) ? "" : $" / {r.Phone}")}"
                }).ToList();

                ViewData["CondominiumId"] = condominiumId;
                ViewData["AssemblyId"] = assemblyId;
                return View(dto);
            }

            var sent = await _apiClient.SendAssemblyInvitesAsync(assemblyId, dto);
            TempData[sent > 0 ? "Success" : "Error"] = sent > 0 ? "Convites enviados." : "Não foi possível enviar convites.";
            return RedirectToAction("Unified", new { condominiumId });
        }

        // GET /assemblies/{assemblyId}/room -> Redirect para o Jitsi
        [HttpGet("/assemblies/{assemblyId:int}/room")]
        [Authorize] // mantém os teus roles conforme precisares
        public async Task<IActionResult> Room(int assemblyId)
        {
            // regra de segurança: não permitir após a data (se já tens IsExpired na API, a API também travará)
            var info = await _apiClient.GetAssemblyRoomInfoAsync(assemblyId);
            if (info == null || string.IsNullOrWhiteSpace(info.JoinUrl))
            {
                TempData["Error"] = "Não foi possível abrir a sala.";
                return RedirectToAction(nameof(Unified));
            }

            return Redirect(info.JoinUrl);
        }


    }
}
