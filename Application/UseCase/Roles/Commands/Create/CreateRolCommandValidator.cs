using Domain.Repositories.Roles;

namespace Application.UseCase.Roles.Commands.Create;

internal sealed class CreateRolCommandValidator : AbstractValidator<CreateRolCommand>
{
    public CreateRolCommandValidator(IRolesRepository _rolesRepository)
    {
        RuleFor(m => m.Rol.Name)
            .MustAsync(async (command, sku, _) =>
            {
                var rol = await _rolesRepository.GetByNameAsync(command.Rol.Name);

                return rol is null;
            })
            .WithMessage("The name must be unique.");
    }
}
