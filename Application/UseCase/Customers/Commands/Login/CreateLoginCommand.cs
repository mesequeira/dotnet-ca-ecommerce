namespace Application.UseCase.Customers.Commands.Login;

public class CreateLoginCommand : IRequest<Response>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
