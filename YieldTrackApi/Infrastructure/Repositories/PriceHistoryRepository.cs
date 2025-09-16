using Application.Interfaces.Repositories;
using Domain;
using Infrastructure.Repositories.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PriceHistoryRepository(YieldTrackContext context) : Repository<PriceHistory>(context), IPriceHistoryRepository
{
    public async Task<IEnumerable<PriceHistory>> GetByAssetIdAsync(Guid assetId, CancellationToken cancellationToken)
    {
        var prices = await _context.PriceHistories
            .Where(p => p.AssetId == assetId)
            .OrderByDescending(p => p.ReferenceDate)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return prices.MapToDomain();
    }
}
