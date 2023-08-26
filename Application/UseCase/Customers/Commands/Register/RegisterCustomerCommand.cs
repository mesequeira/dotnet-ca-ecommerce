namespace Application.UseCase.Customers.Commands.Register;

public class RegisterCustomerCommand : IRequest<Response>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
}
