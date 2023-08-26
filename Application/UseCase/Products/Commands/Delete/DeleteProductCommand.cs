using Domain.Shared;

namespace Application.UseCase.Products.Commands.Delete;

public class DeleteProductCommand : IRequest<Response>
{
    public long ProductId { get; set; }
}

