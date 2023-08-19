using Application.Commands;
using Application.DTOs;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private ISender _mediator;

    public OrdersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<int>> CreateOrder(CreateOrderCommand createCommand)
    {
        var orderId = await _mediator.Send(createCommand);
        return CreatedAtAction(nameof(CreateOrder), orderId);
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<OrderDTO>>> GetAllOrders()
    {
        var getAllQuery = new GetAllOrdersQuery();
        return await _mediator.Send(getAllQuery);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<OrderDTO>> GetOrderById(int id)
    {
        var getById = new GetOrderByIdQuery { OrderId = id };
        return await _mediator.Send(getById);
    }
}