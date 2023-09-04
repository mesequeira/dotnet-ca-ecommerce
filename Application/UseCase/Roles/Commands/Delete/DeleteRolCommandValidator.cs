namespace Application.UseCase.Roles.Commands.Delete;

internal sealed class DeleteRolCommandValidator : AbstractValidator<DeleteRolCommand>
{
    public DeleteRolCommandValidator()
    {
        RuleFor(m => m.Rol.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("The name could not be null or empty");
    }
}
