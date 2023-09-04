namespace Application.UseCase.Authentication.Login;

public class CreateLoginCommand : IRequest<Response>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
