using Application.Commons;
using Application.Interfaces.Repositories;
using Application.UseCases.GetPriceHistoriesByCode.Boundaries;
using Domain;
using MediatR;

namespace Application.UseCases.GetPriceHistoriesByCode;

public sealed class GetPriceHistoriesByCode(
    IPriceHistoryRepository priceRepository
) : IRequestHandler<GetPriceHistoriesByCodeInput, Output>
{
    private readonly IPriceHistoryRepository _priceRepository = priceRepository;

    public async Task<Output> Handle(GetPriceHistoriesByCodeInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var prices = await _priceRepository.GetByAssetIdAsync(input.AssetId, cancellationToken);

        if (!prices.Any())
        {
            output.AddResult(Array.Empty<PriceHistory>());
            return output;
        }

        output.AddResult(prices);
        return output;
    }
}
