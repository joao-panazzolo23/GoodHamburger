using GoodHamburger.Application.Products.Commands;
using GoodHamburger.Application.Result;
using GoodHamburger.Domain.Products.Dtos;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Presentation.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpGet("menu")]
    public async Task<ActionResult<Result<IEnumerable<ProductDto>>>> Menu(
        [FromQuery] GetMenuCommand command,
        CancellationToken token
    )
    {
        var result = await mediator.Send(command, token);
        return StatusCode(result.StatusCode, result);
    }
}