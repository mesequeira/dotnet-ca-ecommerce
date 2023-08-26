using Domain.Shared;

namespace Application.UseCase.Products.Commands.Update;

public class UpdateProductCommand : IRequest<Response>
{
    public long ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public long CategoryId { get; set; }
    public long DiscountId { get; set; }
    public long InventoryId { get; set; }
}
