namespace Application.Dto;

public sealed record PriceHistoryDto(
    Guid Id,
    Guid AssetId,
    DateTime ReferenceDate,
    decimal Price,
    decimal Rate
);
