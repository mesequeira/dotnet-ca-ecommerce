using Domain.Shared;

namespace Application.UseCase.Products.Commands.Create;

public class CreateProductCommand : IRequest<Response>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Sku { get; set; }
    public long CategoryId { get; set; }
    public long DiscountId { get; set; }
    public long InventoryId { get; set; }
}
