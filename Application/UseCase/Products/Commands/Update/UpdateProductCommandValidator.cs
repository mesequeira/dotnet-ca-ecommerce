using Application.UseCase.Products.Commands.Create;
using FluentValidation;

namespace Application.UseCase.Products.Commands.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty()
            .NotNull()
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
    }
}
