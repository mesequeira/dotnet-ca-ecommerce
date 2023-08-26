using Domain.Repositories.Products;

namespace Application.UseCase.Products.Commands.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator(IProductRepository _productRepository)
    {
        RuleFor(m => m.Product.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("The product name can not be empty")
            .MinimumLength(5)
            .WithMessage("Name need be longer than 5 characters.")
            .MaximumLength(500)
            .WithMessage("Name cannot be longer than 500 characters.");

        RuleFor(m => m.Product.Description)
            .MinimumLength(25)
            .WithMessage("Description need be longer than 25 characters.")
            .MaximumLength(4000)
            .WithMessage("Description cannot be longer than 4000 characters.");
        
        RuleFor(m => m.Product.Sku)
            .MustAsync(async (sku, _) => await _productRepository.IsSkuUniqueAsync(sku))
            .WithMessage("The Sku must be unique.");
    }
}
