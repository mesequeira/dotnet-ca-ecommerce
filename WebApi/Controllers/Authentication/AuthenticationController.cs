using Application.UseCase.Authentication.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Authentication;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ApplicationBaseController
{
    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] CreateLoginCommand command) =>
        Ok(await Mediator.Send(command));
}
