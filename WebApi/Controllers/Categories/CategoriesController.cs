using Application.UseCase.Categories.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Categories;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ApplicationBaseController
{

    [HttpGet("all")]
    [ProducesResponseType(typeof(Response<GetAllCategoriesQueryResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCategoriesQuery query) =>
        Ok(await Mediator.Send(query));
}