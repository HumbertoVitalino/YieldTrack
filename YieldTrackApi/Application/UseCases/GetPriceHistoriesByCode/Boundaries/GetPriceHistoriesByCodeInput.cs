using Application.Commons;
using MediatR;

namespace Application.UseCases.GetPriceHistoriesByCode.Boundaries;

public sealed record GetPriceHistoriesByCodeInput(
    Guid AssetId
) : IRequest<Output>;
