using Domain.Abstractions.UnitOfWork;
using Domain.Repositories.Roles;

namespace Application.UseCase.Roles.Commands.Delete;

internal sealed class DeleteRolCommandHandler : IRequestHandler<DeleteRolCommand, Response>
{
    private readonly IRolesRepository _rolesRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger;

    public DeleteRolCommandHandler(
        ILogger logger,
        IRolesRepository rolesRepository,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _rolesRepository = rolesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response> Handle(
        DeleteRolCommand request, 
        CancellationToken cancellationToken)
    {
        var response = new Response();

        var product = await _rolesRepository.GetByNameAsync(request.Rol.Name);

        if (product is null)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.Message = "The specified rol was not found";
            return response;
        }

        await _rolesRepository.DeleteAsync(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.Warning("The rol {0} was deleted at {1}", request.Rol.Name, DateTime.Now);

        response.StatusCode = HttpStatusCode.OK;
        response.Message = "The specified rol was succesfully deleted.";
        return response;
    }
}
