using Application.Common.Interfaces.Authentication;
using Application.Options;
using Domain.Repositories.Customers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services.Authentication;

internal sealed class AuthenticationService : IAuthenticationService
{
    private readonly JwtSettings _jwtSettings;
    private readonly ICustomerRepository _customerRepository;

    public AuthenticationService(JwtSettings jwtSettings, ICustomerRepository customerRepository)
    {
        _jwtSettings = jwtSettings;
        _customerRepository = customerRepository;
    }

    public async Task<string> CreateTokenJwt(string email)
    {
        var customer = await _customerRepository.GetByEmailAsync(email);

        var jwtHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

        var claims = new List<Claim>
        {
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim("userId", customer.Id.ToString()),
               new Claim(ClaimTypes.Role, customer.Rol.Name)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Audience = "https://www.msequeira.dev",
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials =
            new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var securityToken = jwtHandler.CreateToken(tokenDescriptor);

        return jwtHandler.WriteToken(securityToken);
    }
}
