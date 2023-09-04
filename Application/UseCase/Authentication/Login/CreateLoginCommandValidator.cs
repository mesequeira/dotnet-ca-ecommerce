using Application.Helpers;
using Domain.Repositories.Customers;

namespace Application.UseCase.Authentication.Login;

internal sealed class CreateLoginCommandValidator : AbstractValidator<CreateLoginCommand>
{
    public CreateLoginCommandValidator(ICustomerRepository _customerRepository)
    {
        RuleFor(m => m)
            .CustomAsync(async (item, context, ct) =>
            {
                var customer = await _customerRepository.GetByEmailAsync(item.Email); 
                var passwordMatch = PasswordHelper.VerifyPassword(item?.Password, customer?.Password);

                if (customer is null || !passwordMatch)
                {
                    context.AddFailure($"The email or password not match with any of ours records.");
                }
            });
    }
}
