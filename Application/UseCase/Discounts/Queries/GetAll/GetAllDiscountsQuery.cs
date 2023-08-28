using Domain.Dtos.Products.Discounts;

namespace Application.UseCase.Discounts.Queries.GetAll;

public sealed class GetAllDiscountsQuery : IRequest<Response<GetAllDiscountsQueryResponse>>
{ }

public record struct GetAllDiscountsQueryResponse(List<DiscountDto> Discounts)
{ }
