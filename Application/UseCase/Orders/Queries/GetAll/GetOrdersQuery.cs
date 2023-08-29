using Domain.Dtos.Orders;

namespace Application.UseCase.Orders.Queries.GetAll;

public sealed class GetAllOrdersQuery : IRequest<Response<GetAllOrdersQueryResponse>>
{ }

public record struct GetAllOrdersQueryResponse(List<OrderDto> Orders)
{ }