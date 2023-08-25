using Application.Common.Models.Response;
using AutoMapper;
using Domain.Entities.Products;
using Domain.Repositories.Products;
using MediatR;
using Serilog;
using System.Net;

namespace Application.UseCase.Products.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<long>>
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(ILogger logger, IMapper mapper, IProductRepository productRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<Response<long>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        await _productRepository.AddAsync(product);

        return new Response<long>()
        {
            Content = product.Id,
            StatusCode = HttpStatusCode.OK,
        };
    }
}
