using Application.Common.Interfaces.Payment;
using Domain.Repositories.Orders;
using MercadoPago.Client.Preference;

namespace Application.UseCase.Payments.Commands.Create;

internal sealed class CreateReferenceCommandHandler : IRequestHandler<CreateReferenceCommand, Response>
{
    private readonly IPaymentService _paymentService;
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CreateReferenceCommandHandler(IPaymentService paymentService, IOrderRepository orderRepository, IMapper mapper, ILogger logger)
    {
        _paymentService = paymentService;
        _orderRepository = orderRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Response> Handle(CreateReferenceCommand request, CancellationToken cancellationToken)
    {
        var response = new Response();
        
        var order = await _orderRepository.GetByIdAsync(request.OrderId);

        if(order is null)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = "The specified order was not found";
            return response;
        }

        var items = _mapper.Map<List<PreferenceItemRequest>>(order.OrderItems);

        var referenceId = await _paymentService.CreateReferenceAsync(items);

        _logger.Information($"Reference with id {referenceId} was created.");

        response.StatusCode = HttpStatusCode.Created;
        response.Content = referenceId;
        return response;
    }
}
