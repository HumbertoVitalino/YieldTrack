using Domain;

namespace Application.UseCases.NewInvestment.Boundaries;

public static class NewInvestmentMapper
{
    public static UserInvestment MapToDomain(this NewInvestmentInput input) =>
        new(
            Guid.NewGuid(),
            input.UserId,
            input.AssetId,
            input.Quantity,
            input.PurchaseDate,
            input.DueDate
        );
}
