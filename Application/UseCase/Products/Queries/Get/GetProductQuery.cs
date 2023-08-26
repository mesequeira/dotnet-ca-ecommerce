using Domain.Dtos.Products;

namespace Application.UseCase.Products.Queries.Get;

public sealed class GetProductQuery : IRequest<Response<GetProductQueryResponse>>
{
    public long ProductId { get; set; }
}

public record struct GetProductQueryResponse(ProductDto Product)
{ }