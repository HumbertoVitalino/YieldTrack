using Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services;

public class JwtService(
    IConfiguration configuration
) : IJwtService
{
    private readonly IConfiguration _configuration = configuration;

    public async Task<string> GenerateToken(Guid userId, string email)
    {
        var secretKey = _configuration["Jwt:Secret"];
        var key = Encoding.ASCII.GetBytes(secretKey!);
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email)
            ]),
            Expires = DateTime.Now.AddHours(2),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        await Task.Yield();

        return tokenHandler.WriteToken(token);
    }
}
