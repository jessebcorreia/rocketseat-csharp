using FirstAPI.Communication.Requests;
using FirstAPI.Communication.Responses;
using FirstAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers;

public class UserController : FirstAPIControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        List<User> response = new()
        {
            new User {Name = "Example 1", Age = 30, Id = 1},
            new User {Name = "Example 2", Age = 28, Id = 2}
        };

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    public IActionResult GetById([FromHeader] int id)
    {
        User user = new()
        {
            Id = id,
            Age = 70,
            Name = "John Doe"
        };

        return Ok(user);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status200OK)]
    public IActionResult Create([FromBody] RequestRegisterUserJson request)
    {
        ResponseRegisterUserJson response = new()
        {
            Id = 1,
            Name = request.Name,
        };

        return Created(string.Empty, response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status204NoContent)]
    public IActionResult Update([FromRoute] int id)
    {
        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status204NoContent)]
    public IActionResult Update(
    [FromRoute] int id,
    [FromBody] RequestChangePasswordJson request)
    {
        return NoContent();
    }

    [HttpPut("{id}/change-password")]
    public IActionResult ChangePassword(
        [FromRoute] int id,
        [FromBody] RequestChangePasswordJson request
    )
    {
        return NoContent();
    }
}
