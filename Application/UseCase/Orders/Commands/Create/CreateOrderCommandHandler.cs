using Domain.Abstractions.UnitOfWork;
using Domain.Entities.Orders;
using Domain.Repositories.Orders;
using Microsoft.Extensions.Logging;

namespace Application.UseCase.Orders.Commands.Create;

internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response>
{
    private readonly ILogger<CreateOrderCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderCommandHandler(
        ILogger<CreateOrderCommandHandler> logger,
        IMapper mapper,
        IOrderRepository orderRepository,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _mapper = mapper;
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(request.Order);

        await _orderRepository.AddAsync(order);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation($"Order with id {order.Id} was created.");

        return new Response
        {
            Content = order.Id,
            StatusCode = HttpStatusCode.OK,
            Message = "The specified order was successfully created."
        };
    }
}
