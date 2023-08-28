using Domain.Dtos.Products.Categories;

namespace Application.UseCase.Categories.Queries.GetAll;

public sealed class GetAllCategoriesQuery : IRequest<Response<GetAllCategoriesQueryResponse>>
{ }

public record struct GetAllCategoriesQueryResponse(List<CategoryDto> Categories)
{ }