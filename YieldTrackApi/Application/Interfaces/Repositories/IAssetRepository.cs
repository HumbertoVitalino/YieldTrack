using Domain;

namespace Application.Interfaces.Repositories;

public interface IAssetRepository : IRepository<FixedIncomeAsset>
{
    Task<FixedIncomeAsset?> GetAsync(string code, CancellationToken cancellationToken);
    Task InsertAsync(FixedIncomeAsset asset, CancellationToken cancellationToken);
}
