using Application.UseCase.Customers.Commands.Login;
using Application.UseCase.Customers.Commands.Register;
using Application.UseCase.Products.Commands.Create;
using Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Customers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ApplicationBaseController
{
    [HttpPost("register")]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Register([FromBody] RegisterCustomerCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpPost("login")]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] CreateLoginCommand command) =>
    Ok(await Mediator.Send(command));
}
