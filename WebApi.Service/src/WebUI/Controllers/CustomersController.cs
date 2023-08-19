using Application.Commands;
using Application.DTOs;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private ISender _mediator;

    public CustomersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<int>> CreateCustomer(CreateCustomerCommand createCommand)
    {
        var customerId = await _mediator.Send(createCommand);
        return CreatedAtAction(nameof(CreateCustomer), customerId);
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<CustomerDTO>>> GetAllCustomers()
    {
        var getAllQuery = new GetAllCustomersQuery();
        return await _mediator.Send(getAllQuery);
    }
}