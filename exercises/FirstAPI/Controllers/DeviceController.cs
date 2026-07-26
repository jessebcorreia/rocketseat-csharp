using FirstAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers;

public class DeviceController : FirstAPIControllerBase
{

    [HttpGet]
    public IActionResult Get()
    {
        string key = GetCustomKey();
        return Ok(key);
    }
}
