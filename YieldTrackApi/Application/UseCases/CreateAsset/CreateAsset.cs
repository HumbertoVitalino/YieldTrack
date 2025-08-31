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

        var existingAsset = await _assetRepository.GetAsync(input.Code, cancellationToken);

        if (existingAsset is not null)
        {
            output.AddErrorMessage("Asset with the same code already exists.");
            return output;
        }

        await _assetRepository.InsertAsync(input.MapToDomain(), cancellationToken);
        var saved = await _assetRepository.UnitOfWork.CommitAsync(cancellationToken);

        if (!saved)
        {
            output.AddErrorMessage("Failed to save the asset.");
            return output;
        }

        return output;
    }
}
