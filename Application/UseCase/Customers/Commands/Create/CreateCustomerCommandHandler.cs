using Domain.Abstractions.UnitOfWork;
using Domain.Entities.Customers;
using Domain.Repositories.Customers;

namespace Application.UseCase.Customers.Commands.Create;

internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger;

    public CreateCustomerCommandHandler(
        ICustomerRepository customerRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger logger)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Response> Handle(
        CreateCustomerCommand request, 
        CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request.Customer);

        await _customerRepository.AddAsync(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.Information("Customer with id {0} was created.", customer.Id);

        return new Response()
        {
            Content = customer.Id,
            StatusCode = HttpStatusCode.Created,
            Message = "The customer was succesfully created"
        };
    }
}
