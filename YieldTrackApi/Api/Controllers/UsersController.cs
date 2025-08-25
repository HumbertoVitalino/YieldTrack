using Application.Commons;
using Application.UseCases.CreateUser.Boundaries;
using Application.UseCases.LoginUser.Boundaries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController(
    IMediator mediator
) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(typeof(Output), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Output), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserInput request, CancellationToken cancellationToken)
    {
        var output = await _mediator.Send(request, cancellationToken);

        if (!output.IsValid)
            return BadRequest(output);

        return StatusCode(StatusCodes.Status201Created, output);
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(Output), StatusCodes.Status202Accepted)]
    [ProducesResponseType(typeof(Output), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> LoginAsync([FromBody] LoginUserInput request, CancellationToken cancellationToken)
    {
        var output = await _mediator.Send(request, cancellationToken);

        if (!output.IsValid)
            return Unauthorized(output);

        return Accepted(output);
    }
}
