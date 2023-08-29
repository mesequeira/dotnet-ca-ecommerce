using Domain.Dtos.Orders;
using Domain.Repositories.Orders;

namespace Application.UseCase.Orders.Queries.Get;

internal sealed class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Response<GetOrderQueryResponse>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Response<GetOrderQueryResponse>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var response = new Response<GetOrderQueryResponse>();
        var result = await _orderRepository.GetByIdAsync(request.OrderId);

        if (result is null)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = "The specified order was not found";
            return response;
        }

        var order = _mapper.Map<OrderDto>(result);

        response.Content = new GetOrderQueryResponse(order);
        response.StatusCode = HttpStatusCode.OK;
        return response;
    }
}