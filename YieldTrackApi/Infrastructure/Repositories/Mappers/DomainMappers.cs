namespace Infrastructure.Repositories.Mappers;

public static class DomainMappers
{
    public static Domain.User MapToDomain(this Models.User model) =>
        new(
            model.Id,
            model.Name,
            model.Email,
            model.PasswordHash,
            model.PasswordSalt
        );

    public static Domain.FixedIncomeAsset MapToDomain(this Models.FixedIncomeAsset model) =>
        new(
            model.Id,
            model.Code,
            model.Name,
            model.Issuer,
            model.FaceValue,
            model.MaturityDate,
            model.CurrentRate,
            model.RateType
        );

    public static IEnumerable<Domain.FixedIncomeAsset> MapToDomain(this IEnumerable<Models.FixedIncomeAsset> models) =>
        models.Select(x => x.MapToDomain());

    public static Domain.PriceHistory MapToDomain(this Models.PriceHistory model) =>
        new(
            model.Id,
            model.AssetId,
            model.ReferenceDate,
            model.Price,
            model.Rate
        );

    public static IEnumerable<Domain.PriceHistory> MapToDomain(this IEnumerable<Models.PriceHistory> models) =>
        models.Select(x => x.MapToDomain());
}
