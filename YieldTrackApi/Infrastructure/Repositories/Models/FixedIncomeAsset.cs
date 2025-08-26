using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Repositories.Models;

[Table("FixedIncomeAssets")]
public class FixedIncomeAsset : Model
{
    [Required]
    public string Code { get; private set; } = default!;

    [Required]
    public string Name { get; private set; } = default!;

    [Required]
    public string Issuer { get; private set; } = default!;

    [Required]
    public decimal FaceValue { get; private set; }

    [Required]
    public DateTime MaturityDate { get; private set; }

    [Required]
    public decimal CurrentRate { get; private set; }

    [Required]
    public string RateType { get; private set; } = default!;

    public ICollection<PriceHistory> PriceHistory { get; private set; } = [];
    public ICollection<UserInvestment> Investments { get; private set; } = [];

    protected FixedIncomeAsset() { }

    public FixedIncomeAsset(
        Guid id,
        string name,
        string code,
        string issuer,
        DateTime maturityDate,
        decimal faceValue,
        decimal currentRate,
        string rateType,
        DateTime createdAt,
        DateTime updatedAt
    ) : base(id, createdAt, updatedAt)
    {
        Name = name;
        Code = code;
        Issuer = issuer;
        MaturityDate = maturityDate;
        FaceValue = faceValue;
        CurrentRate = currentRate;
        RateType = rateType;
    }
}
