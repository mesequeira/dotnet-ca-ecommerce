using Domain.Dtos.Roles;

namespace Application.UseCase.Roles.Commands.Create;

public sealed class CreateRolCommand : IRequest<Response>
{
    public RolDto Rol { get; set; }
}
