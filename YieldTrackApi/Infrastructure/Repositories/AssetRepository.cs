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

    public async Task<FixedIncomeAsset> UpsertAsync(FixedIncomeAsset asset, CancellationToken cancellationToken)
    {
        var existingAsset = await _context.FixedIncomeAssets
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Code == asset.Code, cancellationToken: cancellationToken);

        if (existingAsset == null)
        {
            return await AddAssetAsync(asset, cancellationToken);
        }

        return UpdateAsset(asset, existingAsset.Id, cancellationToken);
    }

    private async Task<FixedIncomeAsset> AddAssetAsync(FixedIncomeAsset asset, CancellationToken cancellationToken)
    {
        var assetModel = asset.MapToModel();

        await _context.FixedIncomeAssets.AddAsync(assetModel, cancellationToken);

        return asset;
    }

    private FixedIncomeAsset UpdateAsset(FixedIncomeAsset asset, Guid id, CancellationToken cancellationToken)
    {
        var updatedAsset = asset.MapToModel(id);

        _context.FixedIncomeAssets.Update(updatedAsset);

        return updatedAsset.MapToDomain();
    }
}
