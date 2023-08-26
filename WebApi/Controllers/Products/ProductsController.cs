using Application.UseCase.Products.Commands.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController : ApplicationBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpPut]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] CreateProductCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpDelete]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromBody] CreateProductCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpGet]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromBody] CreateProductCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpGet("all")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromBody] CreateProductCommand command) =>
        Ok(await Mediator.Send(command));
}
