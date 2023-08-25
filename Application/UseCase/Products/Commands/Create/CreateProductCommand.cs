using Application.Common.Models.Response;
using MediatR;

namespace Application.UseCase.Products.Commands.Create;

public class CreateProductCommand : IRequest<Response<long>>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public long CategoryId { get; set; }
    public int Stock { get; set; }
}
