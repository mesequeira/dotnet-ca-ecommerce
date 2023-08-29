using Domain.Dtos.Orders;
using Domain.Dtos.Products;
using Domain.Repositories.Orders;
using Domain.Repositories.Products;

namespace Application.UseCase.Orders.Queries.GetAll;

internal sealed class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, Response<GetAllOrdersQueryResponse>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Response<GetAllOrdersQueryResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var response = new Response<GetAllOrdersQueryResponse>();

        var result = await _orderRepository.GetAllAsync();

        if (result is null || result.Count == 0)
        {
            response.StatusCode = HttpStatusCode.OK;
            response.Message = "There are no orders available yet.";
            return response;
        }

        var orders = _mapper.Map<List<OrderDto>>(result);

        response.StatusCode = HttpStatusCode.OK;
        response.Content = new GetAllOrdersQueryResponse(orders);
        return response;
    }
}