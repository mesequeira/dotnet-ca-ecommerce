
using Domain.Abstractions.UnitOfWork;
using Domain.Entities.Products;
using Domain.Repositories.Products;

namespace Application.UseCase.Products.Commands.Create;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response>
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(
        ILogger logger, 
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

        _logger.Information($"Product with id {0} was created.", product.Id);

        return new Response()
        {
            Content = product.Id,
            StatusCode = HttpStatusCode.Created,
            Message = "The specified product was succesfully created."
        };
    }
}
