using Domain.Abstractions.UnitOfWork;
using Domain.Entities.Customers.Roles;
using Domain.Repositories.Roles;

namespace Application.UseCase.Roles.Commands.Create;

internal sealed class CreateRolCommandHandler : IRequestHandler<CreateRolCommand, Response>
{
    private readonly IRolesRepository _rolesRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CreateRolCommandHandler(
        IRolesRepository rolesRepository, 
        ILogger logger, 
        IMapper mapper, 
        IUnitOfWork unitOfWork)
    {
        _rolesRepository = rolesRepository;
        _logger = logger;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response> Handle(
        CreateRolCommand request, 
        CancellationToken cancellationToken)
    {
        var rol = _mapper.Map<Rol>(request.Rol);

        await _rolesRepository.AddAsync(rol);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.Information("Rol with id {0} was created at {1}.", rol.Id, DateTime.Now);

        return new Response()
        {
            Content = rol.Id,
            StatusCode = HttpStatusCode.Created,
            Message = "The rol was succesfully created."
        };

    }
}
