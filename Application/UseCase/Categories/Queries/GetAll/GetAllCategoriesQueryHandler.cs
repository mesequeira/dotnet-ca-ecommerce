using Domain.Dtos.Products.Categories;
using Domain.Repositories.Categories;

namespace Application.UseCase.Categories.Queries.GetAll;

internal sealed class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, Response<GetAllCategoriesQueryResponse>>
{
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(ICategoriesRepository categoriesRepository, IMapper mapper)
    {
        _categoriesRepository = categoriesRepository;
        _mapper = mapper;
    }

    public async Task<Response<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var result = await _categoriesRepository.GetAll();

        var categories = _mapper.Map<List<CategoryDto>>(result);

        return new Response<GetAllCategoriesQueryResponse>()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new GetAllCategoriesQueryResponse(categories)
        };
    }
}
