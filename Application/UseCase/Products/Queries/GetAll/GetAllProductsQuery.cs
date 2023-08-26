using Domain.Dtos.Products;

namespace Application.UseCase.Products.Queries.GetAll;

public sealed class GetAllProductsQuery : IRequest<Response<GetAllProductsQueryResponse>>
{ }

public record struct GetAllProductsQueryResponse(List<ProductDto> Product)
{ }