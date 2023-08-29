
using Domain.Abstractions.UnitOfWork;
using Domain.Entities.Products;
using Domain.Repositories.Products;
using Domain.Shared;
using Microsoft.Extensions.Logging;

namespace Application.UseCase.Products.Commands.Create;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response>
{
    private readonly ILogger<CreateProductCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(
        ILogger<CreateProductCommandHandler> logger, 
        IMapper mapper, 
        IProductRepository productRepository, 
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _mapper = mapper;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request.Product);

        await _productRepository.AddAsync(product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation($"Product with id {product.Id} was created.");

        return new Response()
        {
            Content = product.Id,
            StatusCode = HttpStatusCode.OK,
            Message = "The specified product was succesfully created."
        };
    }
}
