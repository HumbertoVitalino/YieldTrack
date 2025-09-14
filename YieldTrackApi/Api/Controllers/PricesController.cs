using Application.UseCases.GetPriceHistoriesByCode.Boundaries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PricesController(
    IMediator mediator
) : BaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("{assetId}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid assetId, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetPriceHistoriesByCodeInput(assetId), cancellationToken);
        return Ok(response);
    }
}
