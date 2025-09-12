using Domain;

namespace Application.Interfaces.Repositories;

public interface IAssetRepository : IRepository<FixedIncomeAsset>
{
    Task<FixedIncomeAsset?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<FixedIncomeAsset?> GetAsync(string code, CancellationToken cancellationToken);
    Task<FixedIncomeAsset> UpsertAsync(FixedIncomeAsset asset, CancellationToken cancellationToken);
    Task<IEnumerable<FixedIncomeAsset>> GetAsync(CancellationToken cancellationToken);
    Task InsertAsync(FixedIncomeAsset asset, CancellationToken cancellationToken);
}
