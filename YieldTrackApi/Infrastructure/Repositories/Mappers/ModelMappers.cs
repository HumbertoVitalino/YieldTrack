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

    public static Models.FixedIncomeAsset MapToModel(this Domain.FixedIncomeAsset asset) =>
        new(
            asset.Id,
            asset.Code,
            asset.Name,
            asset.Issuer,
            asset.MaturityDate,
            asset.FaceValue,
            asset.CurrentRate,
            asset.RateType,
            asset.CreatedAt,
            asset.UpdatedAt
        );
}
