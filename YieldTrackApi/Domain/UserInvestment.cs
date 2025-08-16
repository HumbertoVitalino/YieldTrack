namespace Domain;

public class UserInvestment(
    Guid? id,
    Guid userId,
    Guid assetId,
    decimal quantity,
    DateTime purchaseDate
) : Entity(id)
{
    public Guid UserId { get; private set; } = userId;
    public Guid AssetId { get; private set; } = assetId;
    public decimal Quantity { get; private set; } = quantity;
    public DateTime PurchaseDate { get; private set; } = purchaseDate;
    private User _user = default!;
    private FixedIncomeAsset _asset = default!;
    public User User => _user;
    public FixedIncomeAsset Asset => _asset;
}
