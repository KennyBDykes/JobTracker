using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin")]
[Route("api/v1/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IApplicationService _service;
    public AdminController(IApplicationService service)
    {
        _service = service;
    }
    [HttpGet("applications/{status}")]
    public async Task<IActionResult> GetApplicationsByStatus([FromRoute] ApplicationStatus status)
    {
        return Ok(await _service.GetApplicationsByStatus(status));
    }
    [HttpPut("applications/{id}")]
    public async Task<IActionResult> UpdateApplication(
     [FromRoute] Guid id,
     [FromBody] UpdateApplicationDto application)
    {
        await _service.UpdateApp(id, application);
        return NoContent();
    }
    [HttpDelete("applications/{id}")]
    public async Task<IActionResult> DeleteApplication([FromRoute] Guid id)
    {
        await _service.DeleteApp(id);
        return NoContent();
    }

}
