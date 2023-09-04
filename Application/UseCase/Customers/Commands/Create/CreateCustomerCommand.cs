using Domain.Dtos.Customers;

namespace Application.UseCase.Customers.Commands.Create;

public class CreateCustomerCommand : IRequest<Response>
{
    public CustomerDto Customer { get; set; }
}
