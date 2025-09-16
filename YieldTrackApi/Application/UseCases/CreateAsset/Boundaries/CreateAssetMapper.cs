using Domain;

namespace Application.UseCases.CreateAsset.Boundaries;

public static class CreateAssetMapper
{
    public static FixedIncomeAsset MapToDomain(this CreateAssetInput input) =>
        new(
            id: Guid.NewGuid(),
            code: input.Code,
            name: input.Name,
            issuer: input.Issuer,
            faceValue: input.FaceValue,
            maturityDate: input.MaturityDate,
            currentRate: input.CurrentRate,
            rateType: input.RateType
        );
}
