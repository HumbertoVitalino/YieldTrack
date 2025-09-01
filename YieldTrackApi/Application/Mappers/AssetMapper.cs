using Application.Dto;
using Domain;

namespace Application.Mappers;

public static class AssetMapper
{
    public static GetAssetDto MapToDto(this FixedIncomeAsset asset) =>
        new(
            asset.Id,
            asset.Code,
            asset.Name,
            asset.Issuer,
            asset.FaceValue,
            asset.MaturityDate,
            asset.CurrentRate,
            asset.RateType,
            asset.PriceHistory.MapToDto()
        );

    public static IEnumerable<GetAssetDto> MapToDto(this IEnumerable<FixedIncomeAsset> assets) =>
        assets.Select(a => a.MapToDto());
}
