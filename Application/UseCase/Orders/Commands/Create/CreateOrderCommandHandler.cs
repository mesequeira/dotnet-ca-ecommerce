using Domain.Abstractions.UnitOfWork;
using Domain.Entities.Orders;
using Domain.Repositories.Orders;

namespace Application.UseCase.Orders.Commands.Create;

internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response>
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderCommandHandler(
        ILogger logger,
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

        _logger.Information("Order with id {0} was created.", order.Id);

        return new Response
        {
            Content = order.Id,
            StatusCode = HttpStatusCode.Created,
            Message = "The specified order was successfully created."
        };
    }
}
