using Domain.Abstractions.UnitOfWork;
using Domain.Entities.Orders;
using Domain.Repositories.Orders;

namespace Application.UseCase.Orders.Commands.Update;

internal sealed class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Response>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var response = new Response();

        var result = await _orderRepository.GetByIdAsync(request.OrderId);

        if (result is null)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = "The specified order was not found";
            return response;
        }

        var order = _mapper.Map<Order>(request.Order);
        order.Id = request.OrderId;
        _orderRepository.UpdateAsync(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        response.StatusCode = HttpStatusCode.OK;
        response.Message = $"The specified order was successfully updated.";
        return response;
    }
}