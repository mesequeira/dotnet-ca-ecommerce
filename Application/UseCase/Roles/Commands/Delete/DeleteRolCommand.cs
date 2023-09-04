using Domain.Dtos.Roles;

namespace Application.UseCase.Roles.Commands.Delete;

public class DeleteRolCommand : IRequest<Response>
{
    public RolDto Rol { get; set; }
}
