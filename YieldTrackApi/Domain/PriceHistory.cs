namespace Domain;

public class PriceHistory(
    Guid? id,
    Guid assetId,
    DateTime referenceDate,
    decimal price,
    decimal rate
) : Entity(id)
{
    public Guid AssetId { get; private set; } = assetId;
    public DateTime ReferenceDate { get; private set; } = referenceDate;
    public decimal Price { get; private set; } = price;
    public decimal Rate { get; private set; } = rate;

    private FixedIncomeAsset _asset = default!;
    public FixedIncomeAsset Asset => _asset;

    public void AddAsset(FixedIncomeAsset asset) => _asset = asset;
}
