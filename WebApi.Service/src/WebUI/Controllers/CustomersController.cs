using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{

    [HttpPost]
    [Route("")]
    public IActionResult CreateCustomer(object customer)
    {
        return CreatedAtAction(nameof(CreateCustomer), customer);
    }

    [HttpGet]
    [Route("")]
    public IActionResult GetAllCustomers()
    {
        var customers = new List<object>();
        return Ok(customers);
    }
}