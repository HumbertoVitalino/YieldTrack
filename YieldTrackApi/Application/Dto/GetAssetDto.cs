namespace Application.Dto;

public sealed record GetAssetDto(
    Guid Id,
    string Code,
    string Name,
    string Issuer,
    decimal FaceValue,
    DateTime MaturityDate,
    decimal CurrentRate,
    string RateType,
    IEnumerable<PriceHistoryDto> PriceHistory
);
