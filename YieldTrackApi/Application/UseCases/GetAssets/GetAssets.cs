using Application.Commons;
using Application.Interfaces.Repositories;
using Application.Mappers;
using Application.UseCases.GetAssets.Boundaries;
using Domain;
using MediatR;

namespace Application.UseCases.GetAssets;

public class GetAssets(
    IAssetRepository assetRepository
) : IRequestHandler<GetAssetsInput, Output>
{
    private readonly IAssetRepository _assetRepository = assetRepository;

    public async Task<Output> Handle(GetAssetsInput request, CancellationToken cancellationToken)
    {
        Output output = new();

        var assets = await _assetRepository.GetAsync(cancellationToken);

        if (!assets.Any())
        {
            output.AddResult(Array.Empty<FixedIncomeAsset>());
            return output;
        }

        output.AddResult(assets.MapToDto());
        return output;
    }
}
