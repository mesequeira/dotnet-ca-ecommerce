using Application.Common.Interfaces.Authentication;

namespace Application.UseCase.Authentication.Login;

internal sealed class CreateLoginCommandHandler : IRequestHandler<CreateLoginCommand, Response>
{
    private readonly ILogger _logger;
    private readonly IAuthenticationService _authenticationService;

    public CreateLoginCommandHandler(
        IAuthenticationService authenticationService, 
        ILogger logger)
    {
        _authenticationService = authenticationService;
        _logger = logger;
    }

    public async Task<Response> Handle(
        CreateLoginCommand request, 
        CancellationToken cancellationToken)
    {
        var token = await _authenticationService.CreateTokenJwt(request.Email);
        _logger.Information("A token was created for the user {0} at {1}", request.Email, DateTime.Now);

        return new Response()
        {
            Content = token,
            StatusCode = HttpStatusCode.OK
        };
    }
}
