using Domain.Dtos.Roles;

namespace Application.UseCase.Roles.Queries.GetAll;

public sealed class GetAllRolesQuery : IRequest<Response<GetAllRolesQueryResponse>>
{ }

public record struct GetAllRolesQueryResponse(List<RolDto> Roles)
{ }