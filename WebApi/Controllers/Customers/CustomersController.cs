using Application.UseCase.Customers.Commands.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Customers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class CustomersController : ApplicationBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command) =>
        Ok(await Mediator.Send(command));
}
