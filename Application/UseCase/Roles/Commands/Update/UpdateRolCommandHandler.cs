using Domain.Abstractions.UnitOfWork;
using Domain.Entities.Customers.Roles;
using Domain.Repositories.Roles;

namespace Application.UseCase.Roles.Commands.Update;

internal sealed class UpdateRolCommandHandler : IRequestHandler<UpdateRolCommand, Response>
{
    private readonly IRolesRepository _rolesRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public UpdateRolCommandHandler(
        ILogger logger,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IRolesRepository rolesRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _rolesRepository = rolesRepository;
    }

    public async Task<Response> Handle(
        UpdateRolCommand request, 
        CancellationToken cancellationToken)
    {
        var response = new Response();

        var result = await _rolesRepository.GetByNameAsync(request.Rol.Name);

        if (result is null)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = "The specified rol was not found";
            return response;
        }

        var rol = _mapper.Map<Rol>(request.Rol);
        
        _rolesRepository.UpdateAsync(rol);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.Information("The rol {0} was succesfully updated at {1}", rol.Name, DateTime.Now);

        response.StatusCode = HttpStatusCode.OK;
        response.Message = $"The specified product was succesfully updated.";
        return response;
    }
}
