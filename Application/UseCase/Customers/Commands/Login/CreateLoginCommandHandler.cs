namespace Application.UseCase.Customers.Commands.Login;

internal sealed class CreateLoginCommandHandler : IRequestHandler<CreateLoginCommand, Response>
{
    

    public async Task<Response> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
    {
        //var result = await _jwtProvider.CreateTokenJwt(request.Email, request.Password);

        return new Response
        {
            Content = "",
            Message = "The customer was succesfully authenticated",
            StatusCode = HttpStatusCode.OK
        };
    }
}
