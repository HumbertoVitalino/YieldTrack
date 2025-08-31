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
}
