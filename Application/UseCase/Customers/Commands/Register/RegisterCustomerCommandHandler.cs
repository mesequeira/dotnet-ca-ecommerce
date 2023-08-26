using Application.Abstractions.Authentication;
using Domain.Abstractions.UnitOfWork;
using Domain.Entities.Customers;
using Domain.Repositories.Customers;
using System.Net;

namespace Application.UseCase.Customers.Commands.Register;

internal sealed class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, Response>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCustomerCommandHandler(IAuthenticationService authenticationService, ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _authenticationService = authenticationService;
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        var identityId = await _authenticationService.RegisterAsync(request.Email, request.Password);

        var customer = new Customer()
        {
            Email = request.Email,
            IdentityId = identityId,
            Name = request.Name
        };

        await _customerRepository.AddAsync(customer);
        await _unitOfWork.SaveChangesAsync(cancellationToken);


        return new Response()
        {
            StatusCode = HttpStatusCode.OK,
            Message = "The customer was succesfully created"
        };
    }
}
