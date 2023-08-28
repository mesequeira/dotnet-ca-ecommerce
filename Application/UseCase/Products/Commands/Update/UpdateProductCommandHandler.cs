using Domain.Abstractions.UnitOfWork;
using Domain.Entities.Products;
using Domain.Repositories.Products;

namespace Application.UseCase.Products.Commands.Update;

internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var response = new Response();

        var result = await _productRepository.GetByIdAsync(request.ProductId);

        if(result is null)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = "The specified product was not found";
            return response;
        }

        var product = _mapper.Map<Product>(request.Product);
        product.Id = request.ProductId;
        _productRepository.UpdateAsync(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        response.StatusCode = HttpStatusCode.OK;
        response.Message = $"The specified product was succesfully updated.";
        return response;

    }
}

