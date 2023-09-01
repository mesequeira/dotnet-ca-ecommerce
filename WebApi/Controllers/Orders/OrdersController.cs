using Application.UseCase.Orders.Commands.Create;
using Application.UseCase.Orders.Commands.Update;
using Application.UseCase.Orders.Queries.Get;
using Application.UseCase.Orders.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Orders;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdersController : ApplicationBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpPut]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] UpdateOrderCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpGet]
    [ProducesResponseType(typeof(Response<GetOrderQueryResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] GetOrderQuery query) =>
        Ok(await Mediator.Send(query));

    [HttpGet("all")]
    [ProducesResponseType(typeof(Response<GetAllOrdersQueryResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllOrdersQuery query) =>
        Ok(await Mediator.Send(query));
}
