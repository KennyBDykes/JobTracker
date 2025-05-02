using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Applicant")]
[Route("api/v1/[controller]")]
[ApiController]
public class ApplicantController : ControllerBase
{
    private readonly IApplicationService _service;
    public ApplicantController(IApplicationService service)
    {
        _service = service;
    }
    [HttpPost("create-application")]
    public async Task<IActionResult> CreateApplication([FromBody] CreateApplicationDto dto)
    {
      try
      {
         var userId = User.FindFirst("id")?.Value;
        if (userId == null)
            return Unauthorized();

        await _service.CreateApp(dto, Guid.Parse(userId));
        return NoContent();

      }catch(Exception e)
      {
        return NotFound();
      }
    }
    
    [HttpGet("applications")]
     public async Task<IActionResult> GetUserApplications()
    {
        var userId = User.FindFirst("id")?.Value;
        if (userId == null)
            return Unauthorized();

        var apps = await _service.GetApplicationsByUserId(Guid.Parse(userId));
        return Ok(apps);
    }

    [HttpDelete("applications/{id}")]
    public async Task<IActionResult> DeleteApplication([FromRoute] Guid id)
    {
       var userId = User.FindFirst("id")?.Value;
        if (userId == null)
            return Unauthorized();

        await _service.DeleteAppByUser(id, Guid.Parse(userId));
        return NoContent();
    }


}