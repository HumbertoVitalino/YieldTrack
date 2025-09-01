using Application.Interfaces.Repositories;
using Domain;
using Infrastructure.Repositories.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AssetRepository(YieldTrackContext context) : Repository<FixedIncomeAsset>(context), IAssetRepository
{
    public async Task<FixedIncomeAsset?> GetAsync(string code, CancellationToken cancellationToken)
    {
        var asset = await _context.FixedIncomeAssets
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Code == code, cancellationToken);

        return asset?.MapToDomain();
    }

    public async Task<IEnumerable<FixedIncomeAsset>> GetAsync(CancellationToken cancellationToken)
    {
        var assets = await _context.FixedIncomeAssets
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return assets.MapToDomain();
    }

    public async Task<FixedIncomeAsset?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var asset = await _context.FixedIncomeAssets
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return asset?.MapToDomain();
    }

    public async Task InsertAsync(FixedIncomeAsset asset, CancellationToken cancellationToken)
    {
        await _context.AddAsync(asset.MapToModel(), cancellationToken);
    }
}
