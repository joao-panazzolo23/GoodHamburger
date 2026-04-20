using GoodHamburger.Application.Products.Commands;
using GoodHamburger.Application.Shared.Result;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Presentation.Product;

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