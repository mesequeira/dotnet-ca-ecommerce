using Domain.Dtos.Products;
using Domain.Repositories.Products;

namespace Application.UseCase.Products.Queries.Get;

internal sealed class GetProductQueryHandler : IRequestHandler<GetProductQuery, Response<GetProductQueryResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<Response<GetProductQueryResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var response = new Response<GetProductQueryResponse>();
        var result = await _productRepository.GetByIdAsync(request.ProductId);

        if(result is null)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = "The specified product was not found";
            return response;
        }

        var product = _mapper.Map<ProductDto>(result);

        response.Content = new GetProductQueryResponse(product);
        response.StatusCode = HttpStatusCode.OK;
        return response;
    }
}
