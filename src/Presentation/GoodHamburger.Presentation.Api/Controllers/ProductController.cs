using GoodHamburger.Application.Products.Commands;
using GoodHamburger.Application.Result;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Presentation.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Result<Unit>>> Create(
        [FromBody] CreateProductCommand command,
        CancellationToken token
    )
    {
        var result = await mediator.Send(command, token);
        return StatusCode(result.StatusCode, result);
    }
}