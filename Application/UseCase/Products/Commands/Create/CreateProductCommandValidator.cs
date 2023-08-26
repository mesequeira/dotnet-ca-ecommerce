using Domain.Repositories.Products;

namespace Application.UseCase.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator(IProductRepository _productRepository)
    {
        RuleFor(product => product.Name)
            .NotEmpty()
            .WithMessage("The product name can not be empty")
            .MinimumLength(5)
            .WithMessage("Name need be longer than 5 characters.")
            .MaximumLength(500)
            .WithMessage("Name cannot be longer than 500 characters.");

        RuleFor(product => product.Description)
            .MinimumLength(25)
            .WithMessage("Description need be longer than 25 characters.")
            .MaximumLength(4000)
            .WithMessage("Description cannot be longer than 4000 characters.");

        RuleFor(product => product.Sku)
            .MustAsync(async (sku, _) => await _productRepository.IsSkuUniqueAsync(sku))
            .WithMessage("The Sku must be unique.");
    }
}
