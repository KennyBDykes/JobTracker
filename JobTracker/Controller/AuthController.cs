using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[Route("api/v1/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private IUserService _userService;
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }
     [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var token = await _userService.Authenticate(dto);
        if (token == null)
        {
            return Unauthorized("Invalid credentials");
        }

        return Ok(new { Token = token });
    }

}