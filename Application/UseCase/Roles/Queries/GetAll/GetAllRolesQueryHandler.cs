using Domain.Dtos.Roles;
using Domain.Repositories.Roles;

namespace Application.UseCase.Roles.Queries.GetAll;

internal sealed class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, Response<GetAllRolesQueryResponse>>
{
    private readonly IRolesRepository _rolesRepository;
    private readonly IMapper _mapper;

    public GetAllRolesQueryHandler(
        IMapper mapper, 
        IRolesRepository rolesRepository)
    {
        _mapper = mapper;
        _rolesRepository = rolesRepository;
    }

    public async Task<Response<GetAllRolesQueryResponse>> Handle(
        GetAllRolesQuery request, 
        CancellationToken cancellationToken)
    {
        var result = await _rolesRepository.GetAllAsync();

        var roles = _mapper.Map<List<RolDto>>(result);

        return new Response<GetAllRolesQueryResponse>()
        {
            Content = new GetAllRolesQueryResponse(roles),
            StatusCode = HttpStatusCode.OK
        };
    }
}
