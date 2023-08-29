using Domain.Repositories.Products;

namespace Application.UseCase.Orders.Commands.Create;
public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator(IProductRepository _productRepository)
    {
        RuleForEach(m => m.Order.OrderItems)
            .CustomAsync(async (item, context, ct) =>
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);

                if (product is null)
                {
                    context.AddFailure($"Invalid product Id {item.ProductId} in OrderItems");
                }

                if (item.Quantity > product.Inventory.Quantity)
                {
                    context.AddFailure($"The quantity selected for product {product.Name} exceeds the available stock");
                }
            })
            .Custom((orderItem, context) =>
            {
                var orderItems = context.InstanceToValidate.Order.OrderItems;

                var duplicated = orderItems.Where(m => m.ProductId == orderItem.ProductId).Count() > 1;

                if (duplicated)
                {
                    context.AddFailure($"You add multiple times the product {orderItem.ProductId} for the same order.");
                }
            });
    }
}