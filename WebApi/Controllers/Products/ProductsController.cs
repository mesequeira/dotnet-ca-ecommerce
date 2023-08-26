using Application.UseCase.Products.Commands.Create;
using Application.UseCase.Products.Commands.Update;
using Application.UseCase.Products.Queries.Get;
using Application.UseCase.Products.Queries.GetAll;
using Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ApplicationBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpPut]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpDelete]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromBody] CreateProductCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpGet]
    [ProducesResponseType(typeof(Response<GetProductQueryResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] GetProductQuery query) =>
        Ok(await Mediator.Send(query));

    [HttpGet("all")]
    [ProducesResponseType(typeof(Response<GetAllProductsQueryResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQuery query) =>
        Ok(await Mediator.Send(query));
}
