using Domain;

namespace Application.Interfaces.Repositories;

public interface IPriceHistoryRepository : IRepository<PriceHistory>
{
    Task<IEnumerable<PriceHistory>> GetByAssetIdAsync(Guid assetId, CancellationToken cancellationToken);
}
