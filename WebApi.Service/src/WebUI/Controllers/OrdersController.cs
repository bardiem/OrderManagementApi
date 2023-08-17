using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{

    [HttpPost]
    [Route("")]
    public IActionResult CreateOrder(object order)
    {
        return CreatedAtAction(nameof(CreateOrder), order);
    }

    [HttpGet]
    [Route("")]
    public IActionResult GetAllOrders()
    {
        var orders = new List<object>();
        return Ok(orders);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetOrderById()
    {
        var order = new object();
        return Ok(order);
    }
}