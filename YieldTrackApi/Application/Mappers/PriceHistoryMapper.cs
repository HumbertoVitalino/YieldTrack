using Application.Dto;
using Domain;

namespace Application.Mappers;

public static class PriceHistoryMapper
{
    public static PriceHistoryDto MapToDto(this PriceHistory price) =>
        new(
            price.Id,
            price.AssetId,
            price.ReferenceDate,
            price.Price,
            price.Rate
        );

    public static IEnumerable<PriceHistoryDto> MapToDto(this IEnumerable<PriceHistory> prices) =>
        prices.Select(x => x.MapToDto());
}
