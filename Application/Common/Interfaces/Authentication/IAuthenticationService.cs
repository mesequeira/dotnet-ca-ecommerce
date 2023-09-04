namespace Application.Common.Interfaces.Authentication;

public interface IAuthenticationService
{
    Task<string> CreateTokenJwt(string email);
}
