using Domain.Dtos.Orders;

namespace Application.UseCase.Orders.Commands.Update;

public class UpdateOrderCommand : IRequest<Response>
{
    public long OrderId { get; set; }
    public OrderDto Order { get; set; }
}