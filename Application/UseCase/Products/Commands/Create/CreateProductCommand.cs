using Application.Common.Models.Response;
using MediatR;

namespace Application.UseCase.Products.Commands.Create;

public class CreateProductCommand : IRequest<Response<long>>
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public double Precio { get; set; }
    public long Categoria { get; set; }
    public int Stock { get; set; }
}
