using Domain.Abstractions.UnitOfWork;
using Domain.Repositories.Products;

namespace Application.UseCase.Products.Commands.Delete;

internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var response = new Response();

        var product = await _productRepository.GetByIdAsync(request.ProductId);

        if (product is null)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = "The specified product was not found";
            return response;
        }

        await _productRepository.DeleteAsync(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        response.StatusCode = HttpStatusCode.OK;
        response.Message = "The specified product was succesfully deleted.";
        return response;
    }
}
