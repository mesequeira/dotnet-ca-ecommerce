using Application.Common.Interfaces.Authentication;
using Application.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services.Authentication;

internal sealed class AuthenticationService : IAuthenticationService
{
    private readonly JwtSettings _jwtSettings;

    public AuthenticationService(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }

    public object RegisterAsync(string email)
    {

        var jwtHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

        var claims = new List<Claim>
        {
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim("userId", email)
            };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Audience = "https://www.msequeira.dev",
            Expires = DateTime.Now.Add(_jwtSettings.TokenLifetime),
            SigningCredentials =
            new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };


        var token = jwtHandler.CreateToken(tokenDescriptor);

        return Task.FromResult(new 
        {
            IsSuccess = true,
            Token = jwtHandler.WriteToken(token)
        });
    }
}
