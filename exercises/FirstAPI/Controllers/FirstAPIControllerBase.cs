using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class FirstAPIControllerBase : ControllerBase
{
    public string Author { get; set; } = "John Doe";

    protected string GetCustomKey()
    {
        return Request.Headers["MyKey"].ToString();
    }

    [HttpGet("healthy")]
    public IActionResult Healthy()
    {
        return Ok("Its working");
    }
}
