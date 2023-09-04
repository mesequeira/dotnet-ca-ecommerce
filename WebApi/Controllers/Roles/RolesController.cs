using Application.UseCase.Roles.Commands.Create;
using Application.UseCase.Roles.Commands.Delete;
using Application.UseCase.Roles.Commands.Update;
using Application.UseCase.Roles.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Roles;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Administrator")]
public class RolesController : ApplicationBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateRolCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpPut]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] UpdateRolCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpDelete]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromBody] DeleteRolCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpGet("all")]
    [ProducesResponseType(typeof(Response<GetAllRolesQueryResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllRolesQuery query) =>
        Ok(await Mediator.Send(query));
}
