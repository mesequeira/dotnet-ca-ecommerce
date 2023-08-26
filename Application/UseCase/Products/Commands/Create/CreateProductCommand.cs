using Domain.Dtos.Products;

namespace Application.UseCase.Products.Commands.Create;

public class CreateProductCommand : IRequest<Response>
{
    public ProductDto Product { get; set; }
}
