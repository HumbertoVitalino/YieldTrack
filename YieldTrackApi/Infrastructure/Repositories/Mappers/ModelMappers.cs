namespace Infrastructure.Repositories.Mappers;

public static class ModelMappers
{
    public static Models.User MapToModel(this Domain.User user) =>
        new(
            user.Id,
            user.Name,
            user.Email,
            user.PasswordHash,
            user.PasswordSalt,
            user.CreatedAt,
            user.UpdatedAt
        );

    public static Models.FixedIncomeAsset MapToModel(this Domain.FixedIncomeAsset asset, Guid? id = null)
    {
        var model = new Models.FixedIncomeAsset(
            id ?? asset.Id,
            asset.Name,
            asset.Code,
            asset.Issuer,
            asset.MaturityDate,
            asset.FaceValue,
            asset.CurrentRate,
            asset.RateType,
            asset.CreatedAt,
            asset.UpdatedAt
        );

        var modelPrice = asset.PriceHistory.MapToModel();
        model.AddPriceHistory(modelPrice);

        return model;
    }

    public static Models.PriceHistory MapToModel(this Domain.PriceHistory priceHistory) =>
        new(
            priceHistory.Id,
            priceHistory.ReferenceDate,
            priceHistory.Price,
            priceHistory.Rate,
            priceHistory.CreatedAt,
            priceHistory.UpdatedAt
        );

    public static IEnumerable<Models.PriceHistory> MapToModel(this IEnumerable<Domain.PriceHistory> assets) =>
        assets.Select(a => a.MapToModel());

}
