using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Repositories.Models;

[Table("PriceHistory")]
public class PriceHistory : Model
{
    [Required]
    public Guid AssetId { get; private set; }

    [ForeignKey(nameof(AssetId))]
    public FixedIncomeAsset Asset { get; private set; } = default!;

    [Required]
    public DateTime ReferenceDate { get; private set; }

    [Required]
    public decimal Price { get; private set; }

    [Required]
    public decimal Rate { get; private set; }

    protected PriceHistory() { }

    public PriceHistory(
        Guid id,
        DateTime referenceDate,
        decimal price,
        decimal rate,
        DateTime createdAt,
        DateTime updatedAt
    ) : base(id, createdAt, updatedAt)
    {
        ReferenceDate = referenceDate;
        Price = price;
        Rate = rate;
    }
}
