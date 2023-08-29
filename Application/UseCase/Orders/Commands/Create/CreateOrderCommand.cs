using Domain.Dtos.Orders;

namespace Application.UseCase.Orders.Commands.Create;

public class CreateOrderCommand : IRequest<Response>
{
    public OrderDto Order { get; set; }
}
