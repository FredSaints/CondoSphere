using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("diag")]
public class DiagController : ControllerBase
{
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Content($"OK {DateTime.UtcNow:o}\n" +
                       $"Scheme={Request.Scheme} Host={Request.Host} Path={Request.Path}\n" +
                       $"Auth={(User.Identity?.IsAuthenticated == true ? "Yes" : "No")} User={User.Identity?.Name ?? "(anon)"}",
                       "text/plain");
    }
}