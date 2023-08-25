using Application.Common.Models.Response;
using Domain.Repositories.Products;
using MediatR;

namespace Application.UseCase.Products.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<long>>
{
    

    public Task<Response<long>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var response = new Response<long>();



        return Task.FromResult(response);
    }
}
