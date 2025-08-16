using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Repositories.Models;

public class UserInvestment : Model
{
    [Required]
    public Guid UserId { get; private set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; private set; } = default!;

    [Required]
    public Guid AssetId { get; private set; }

    [ForeignKey(nameof(AssetId))]
    public FixedIncomeAsset Asset { get; private set; } = default!;

    [Required]
    public decimal Quantity { get; private set; }

    [Required]
    public DateTime PurchaseDate { get; private set; }

    protected UserInvestment() { }

    public UserInvestment(
        Guid id,
        Guid userId,
        Guid assetId,
        decimal quantity,
        DateTime purchaseDate,
        DateTime createdAt,
        DateTime updatedAt
    ) : base(id, createdAt, updatedAt)
    {
        UserId = userId;
        AssetId = assetId;
        Quantity = quantity;
        PurchaseDate = purchaseDate;
    }
}
