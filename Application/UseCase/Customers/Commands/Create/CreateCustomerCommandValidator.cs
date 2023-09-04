using Domain.Repositories.Customers;

namespace Application.UseCase.Customers.Commands.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator(ICustomerRepository _customerRepository)
    {
        RuleFor(m => m.Customer.Email)
            .NotEmpty()
            .WithMessage("The Email can not be empty")
            .EmailAddress()
            .WithMessage("The format for the Email is not correct")
            .MustAsync(async (email, _) =>
            {
                var customer = await _customerRepository.GetByEmailAsync(email);

                return customer is null;
            })
            .WithMessage("The Email must be unique.");

        RuleFor(m => m.Customer.Password)
            .NotEmpty()
            .WithMessage("The password is required.");

        RuleFor(m => m.Customer.Name)
            .NotEmpty()
            .WithMessage("The name is required.")
            .Length(1, 150)
            .WithMessage("The name must be between 1 and 150 characters.");

        RuleFor(m => m.Customer.LastName)
            .NotEmpty()
            .WithMessage("The last name is required.")
            .Length(1, 150)
            .WithMessage("The last name must be between 1 and 150 characters.");

        RuleFor(m => m.Customer.City)
            .NotEmpty()
            .WithMessage("The city is required.")
            .Length(1, 200)
            .WithMessage("The city must be between 1 and 200 characters.");

        RuleFor(m => m.Customer.PostalCode)
            .NotEmpty()
            .WithMessage("The postal code is required.");

        RuleFor(m => m.Customer.Address1)
            .NotEmpty()
            .WithMessage("The address is required.");

        RuleFor(m => m.Customer.Birthday)
            .NotEmpty()
            .WithMessage("The birthday is required.");
    }
}
