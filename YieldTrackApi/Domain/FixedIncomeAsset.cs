namespace Domain;

public class FixedIncomeAsset(
    Guid? id,
    string code,
    string name,
    string issuer,
    decimal faceValue,
    DateTime maturityDate,
    decimal currentRate,
    string rateType
    ) : Entity(id)
{
    public string Code { get; private set; } = code;
    public string Name { get; private set; } = name;
    public string Issuer { get; private set; } = issuer;
    public decimal FaceValue { get; private set; } = faceValue;
    public DateTime MaturityDate { get; private set; } = maturityDate;
    public decimal CurrentRate { get; private set; } = currentRate;
    public string RateType { get; private set; } = rateType;
    private List<PriceHistory> _priceHistory = [];
    private List<UserInvestment> _investments = [];
    public IReadOnlyCollection<PriceHistory> PriceHistory => _priceHistory;
    public IReadOnlyCollection<UserInvestment> UserInvestments => _investments;

    public void CreatePriceHistory()
    {
        PriceHistory price = new(
            id: Guid.Empty,
            assetId: Id,
            referenceDate: DateTime.Now,
            price: FaceValue,
            rate: CurrentRate
        );
        price.AddAsset(this);
        _priceHistory.Add(price);
    }
}
