using GoodHamburger.Application.Orders.Commands;
using GoodHamburger.Application.Orders.Dtos;
using GoodHamburger.Application.Result;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Presentation.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class OrderController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Result<Unit>>> Create([FromBody] CreateOrderCommand command, CancellationToken ct)
    {
        var result = await mediator.Send(command, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPut]
    public async Task<ActionResult<Result<Unit>>> Update([FromBody] UpdateOrderCommand command, CancellationToken ct)
    {
        var result = await mediator.Send(command, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpDelete]
    public async Task<ActionResult<Result<Unit>>> Delete([FromBody] DeleteOrderCommand command, CancellationToken ct)
    {
        var result = await mediator.Send(command, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<ActionResult<Result<IEnumerable<OrderDto>>>> Get([FromQuery] GetOrdersByEmailQuery command, CancellationToken ct)
    {
        var result = await mediator.Send(command, ct);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public async Task<ActionResult<Result<OrderDto>>> GetById([FromQuery] GetOrderByIdQuery command, CancellationToken ct)
    {
        var result = await mediator.Send(command, ct);
        return StatusCode(result.StatusCode, result);
    }



}