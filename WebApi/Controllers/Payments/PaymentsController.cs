﻿using Application.UseCase.Payments.Commands.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Payments;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Customer")]
[Authorize(Roles = "Administrator")]
public class PaymentsController : ApplicationBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateReference([FromBody] CreateReferenceCommand command) =>
        Ok(await Mediator.Send(command));
}