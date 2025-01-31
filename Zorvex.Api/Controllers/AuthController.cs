using MediatR;
using Microsoft.AspNetCore.Mvc;
using Zorvex.Application.Users.Commands;
using Zorvex.Application.Users.Dtos;
using Zorvex.Application.Users.Queries;

namespace Zorvex.Api.Controllers;
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(new { UserId = userId });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _mediator.Send(new GetUserQuery(request.Username));
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return Unauthorized();

        // Generate token/JWT here if needed
        return Ok(new { user.Id, user.Username });
    }
}
