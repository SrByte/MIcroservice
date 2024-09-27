using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
{
    if (userLogin.Username == "admin" && userLogin.Password == "123")
    {
        var token = await GenerateJwtTokenAsync();
        return Ok(new { token });
    }
    return Unauthorized();
}

   private async Task<string> GenerateJwtTokenAsync()
{
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
        issuer: _configuration["Jwt:Issuer"],
        audience: _configuration["Jwt:Audience"],
        expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
        signingCredentials: credentials);

    return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
}

}

public class UserLogin
{
    public string Username { get; set; }
    public string Password { get; set; }
}
