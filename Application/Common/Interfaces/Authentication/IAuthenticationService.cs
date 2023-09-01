namespace Application.Common.Interfaces.Authentication;

public interface IAuthenticationService
{
    object RegisterAsync(string email);
}
