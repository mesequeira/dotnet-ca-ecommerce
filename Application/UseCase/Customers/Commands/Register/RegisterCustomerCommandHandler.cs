using Application.Common.Interfaces.Authentication;
using Domain.Abstractions.UnitOfWork;
using Domain.Entities.Customers;
using Domain.Repositories.Customers;
using Microsoft.IdentityModel.Tokens;

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
        var identityId = _authenticationService.RegisterAsync(request.Email);

        return new Response()
        {
            Content = identityId,
            StatusCode = HttpStatusCode.Created,
            Message = "The customer was succesfully created"
        };
    }
}
