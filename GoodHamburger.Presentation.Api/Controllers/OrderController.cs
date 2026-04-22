using GoodHamburger.Application.Orders.Commands;
using GoodHamburger.Application.Result;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Presentation.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Result<Unit>>> Create([FromBody] CreateOrderCommand command, CancellationToken ct)
    {
        var result = await mediator.Send(command, ct);
        return StatusCode(result.StatusCode, result);
    }
}