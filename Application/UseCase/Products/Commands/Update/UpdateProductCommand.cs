using Domain.Dtos.Products;

namespace Application.UseCase.Products.Commands.Update;

public class UpdateProductCommand : IRequest<Response>
{
    public long ProductId { get; set; }
    public ProductDto Product { get; set; }
}
