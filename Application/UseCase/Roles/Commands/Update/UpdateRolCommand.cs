using Domain.Dtos.Roles;

namespace Application.UseCase.Roles.Commands.Update;

public sealed class UpdateRolCommand : IRequest<Response>
{
    public RolDto Rol { get; set; }
}
