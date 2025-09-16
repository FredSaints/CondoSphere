using CondoSphere.Core;
using CondoSphere.Core.DTOs.Assemblies;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.Web.Controllers
{
    [Authorize]
    public class AssembliesController : Controller
    {
        private readonly ApiClient _apiClient;
        public AssembliesController(ApiClient apiClient) => _apiClient = apiClient;

        // ===== ADMIN: ver todas =====
        [HttpGet("~/admin/assemblies")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> All()
        {
            var list = await _apiClient.GetCompanyAssembliesAsync();
            return View("All", list);
        }

        // ===== MANAGER: escolher condomínio (atalho do menu) =====
        [HttpGet("~/assemblies/select-condo")]
        [Authorize(Roles = RoleConstants.CondoManager)]
        public IActionResult SelectCondo()
        {
            // Reusa a página onde o manager já escolhe o condomínio
            return RedirectToAction("Index", "CondoManagement");
        }

        // ===== MANAGER: lista por condomínio =====
        // /condo-management/{condominiumId}/assemblies
        [HttpGet("condo-management/{condominiumId:int}/assemblies")]
        [Authorize(Roles = RoleConstants.CondoManager)]
        public async Task<IActionResult> Index(int condominiumId)
        {
            var list = await _apiClient.GetAssembliesForCondominiumAsync(condominiumId);
            ViewData["CondominiumId"] = condominiumId;
            return View(list);
        }

        // ===== MANAGER: criar =====
        [HttpGet("condo-management/{condominiumId:int}/assemblies/create")]
        [Authorize(Roles = RoleConstants.CondoManager)]
        public IActionResult Create(int condominiumId)
        {
            return View(new CreateAssemblyDto
            {
                CondominiumId = condominiumId,
                ScheduledAt = DateTime.Now.AddDays(1)
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

        // ===== MANAGER: convite =====
        [HttpGet("condo-management/{condominiumId:int}/assemblies/{assemblyId:int}/invite")]
        [Authorize(Roles = RoleConstants.CondoManager)]
        public IActionResult Invite(int condominiumId, int assemblyId)
        {
            ViewData["CondominiumId"] = condominiumId;
            ViewData["AssemblyId"] = assemblyId;
            return View(new SendAssemblyInvitesDto());
        }

        [HttpPost("condo-management/{condominiumId:int}/assemblies/{assemblyId:int}/invite")]
        [Authorize(Roles = RoleConstants.CondoManager)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Invite(int condominiumId, int assemblyId, SendAssemblyInvitesDto dto)
        {
            var sent = await _apiClient.SendAssemblyInvitesAsync(assemblyId, dto);
            TempData[sent > 0 ? "SuccessMessage" : "ErrorMessage"] =
                sent > 0 ? $"Convites enviados: {sent}." : "Não foi possível enviar convites.";
            return RedirectToAction(nameof(Index), new { condominiumId });
        }

        // ===== SALA (chat) =====
        [HttpGet("condo-management/{condominiumId:int}/assemblies/{assemblyId:int}/room")]
        public async Task<IActionResult> Room(int condominiumId, int assemblyId)
        {
            var messages = await _apiClient.GetAssemblyMessagesAsync(assemblyId);
            ViewData["CondominiumId"] = condominiumId;
            ViewData["AssemblyId"] = assemblyId;
            return View(messages);
        }

        [HttpPost("condo-management/{condominiumId:int}/assemblies/{assemblyId:int}/room/message")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostMessage(int condominiumId, int assemblyId, PostAssemblyMessageDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Message))
            {
                TempData["ErrorMessage"] = "Mensagem vazia.";
                return RedirectToAction(nameof(Room), new { condominiumId, assemblyId });
            }

            var ok = await _apiClient.PostAssemblyMessageAsync(assemblyId, dto);
            if (ok == null) TempData["ErrorMessage"] = "Falha ao enviar mensagem.";
            return RedirectToAction(nameof(Room), new { condominiumId, assemblyId });
        }
    }
}
