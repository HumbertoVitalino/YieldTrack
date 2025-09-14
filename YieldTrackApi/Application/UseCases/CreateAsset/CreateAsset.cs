using Application.Commons;
using Application.Interfaces.Repositories;
using Application.UseCases.CreateAsset.Boundaries;
using MediatR;

namespace Application.UseCases.CreateAsset;

public sealed class CreateAsset(
    IAssetRepository assetRepository
) : IRequestHandler<CreateAssetInput, Output>
{
    private readonly IAssetRepository _assetRepository = assetRepository;

    public async Task<Output> Handle(CreateAssetInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var asset = input.MapToDomain();
        asset.CreatePriceHistory();

        await _assetRepository.UpsertAsync(asset, cancellationToken);

        var saved = await _assetRepository.UnitOfWork.CommitAsync(cancellationToken);
        if (!saved)
        {
            output.AddErrorMessage("Failed to save the asset.");
            return output;
        }

        return output;
    }
}
