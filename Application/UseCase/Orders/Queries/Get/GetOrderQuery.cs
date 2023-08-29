using Domain.Dtos.Orders;

namespace Application.UseCase.Orders.Queries.Get;

public sealed class GetOrderQuery : IRequest<Response<GetOrderQueryResponse>>
{
    public long OrderId { get; set; }
}

public record struct GetOrderQueryResponse(OrderDto Order)
{ }