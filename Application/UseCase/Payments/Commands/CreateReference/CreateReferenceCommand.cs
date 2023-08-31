namespace Application.UseCase.Payments.Commands.Create;

public class CreateReferenceCommand : IRequest<Response>
{
    public long OrderId { get; set; }
}
