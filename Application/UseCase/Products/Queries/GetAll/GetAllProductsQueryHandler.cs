using Domain.Dtos.Products;
using Domain.Repositories.Products;

namespace Application.UseCase.Products.Queries.GetAll;

internal sealed class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Response<GetAllProductsQueryResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<Response<GetAllProductsQueryResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var response = new Response<GetAllProductsQueryResponse>();

        var result = await _productRepository.GetAllAsync();

        if(result is null || result.Count == 0)
        {
            response.StatusCode = HttpStatusCode.OK;
            response.Message = "There is no exist any product yet.";
            return response;
        }

        var products = _mapper.Map<List<ProductDto>>(result);

        response.StatusCode = HttpStatusCode.OK;
        response.Content = new GetAllProductsQueryResponse(products);
        return response;
    }
}
