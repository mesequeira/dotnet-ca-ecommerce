using Domain.Repositories.Products;

namespace Application.UseCase.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator(IProductRepository _productRepository)
    {
        RuleFor(m => m.Product.Name)
            .NotEmpty()
            .WithMessage("The product name can not be empty")
            .Length(5, 500)
            .WithMessage("The product name must be between 5 and 500 characters.");

        RuleFor(m => m.Product.Description)
            .Length(25, 4000)
            .WithMessage("The product description must be between 25 and 4000 characters.");

        RuleFor(m => m.Product.Inventory)
            .NotEmpty()
            .WithMessage("You need to insert an inventory to the product");

        RuleFor(m => m.Product.Sku)
            .MustAsync(async (sku, _) => await _productRepository.IsSkuUniqueAsync(sku))
            .WithMessage("The Sku must be unique.");
    }
}
