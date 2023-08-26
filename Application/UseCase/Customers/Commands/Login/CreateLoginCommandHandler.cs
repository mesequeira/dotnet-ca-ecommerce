using Application.Abstractions.Authentication;
using System.Net;

namespace Application.UseCase.Customers.Commands.Login;

internal sealed class CreateLoginCommandHandler : IRequestHandler<CreateLoginCommand, Response>
{
    private readonly IJwtProvider _jwtProvider;

    public CreateLoginCommandHandler(IJwtProvider jwtProvider)
    {
        _jwtProvider = jwtProvider;
    }

    public async Task<Response> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _jwtProvider.GetForCredentialsAsync(request.Email, request.Password);

        return new Response
        {
            Content = result,
            Message = "The customer was succesfully authenticated",
            StatusCode = HttpStatusCode.OK
        };
    }
}
