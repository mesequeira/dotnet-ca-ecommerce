using Domain.Dtos.Products.Discounts;
using Domain.Repositories.Discounts;

namespace Application.UseCase.Discounts.Queries.GetAll;

internal sealed class GetAllDiscountsQueryHandler : IRequestHandler<GetAllDiscountsQuery, Response<GetAllDiscountsQueryResponse>>
{
    private readonly IDiscountRepository _discountRepository;
    private readonly IMapper _mapper;

    public GetAllDiscountsQueryHandler(IDiscountRepository discountRepository, IMapper mapper)
    {
        _discountRepository = discountRepository;
        _mapper = mapper;
    }

    public async Task<Response<GetAllDiscountsQueryResponse>> Handle(GetAllDiscountsQuery request, CancellationToken cancellationToken)
    {
        var response = new Response<GetAllDiscountsQueryResponse>();
        var result = await _discountRepository.GetAll();

        if (result is null || result.Count == 0)
        {
            response.StatusCode = HttpStatusCode.OK;
            response.Message = "There is no exist any discount yet.";
            return response;
        }

        var discounts = _mapper.Map<List<DiscountDto>>(result);

        response.StatusCode = HttpStatusCode.OK;
        response.Content = new GetAllDiscountsQueryResponse(discounts);
        return response;
    }
}
