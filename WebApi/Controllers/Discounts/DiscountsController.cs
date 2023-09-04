using Application.UseCase.Discounts.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Discounts;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Administrator")]
public class DiscountsController : ApplicationBaseController
{

    [HttpGet("all")]
    [ProducesResponseType(typeof(Response<GetAllDiscountsQueryResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllDiscountsQuery query) =>
        Ok(await Mediator.Send(query));
}