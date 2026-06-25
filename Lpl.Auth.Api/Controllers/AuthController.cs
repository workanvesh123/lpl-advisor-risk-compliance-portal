using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Lpl.Auth.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private const string SecretKey = "LplDemoJwtSecretKeyForInterviewPreparation12345";

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        if (request.UserName == "admin" && request.Password == "admin123")
        {
            var token = GenerateJwtToken(request.UserName, "ComplianceReviewer");

            return Ok(new LoginResponse
            {
                Token = token,
                UserName = request.UserName,
                Role = "ComplianceReviewer"
            });
        }

        return Unauthorized("Invalid username or password");
    }

    private static string GenerateJwtToken(string userName, string role)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.Role, role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "Lpl.Auth.Api",
            audience: "Lpl.Compliance.Api",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class LoginRequest
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}