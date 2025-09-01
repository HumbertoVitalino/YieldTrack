using Application.Commons;
using Application.Interfaces.Repositories;
using Application.Mappers;
using Application.UseCases.GetAsset.Boundaries;
using MediatR;

namespace Application.UseCases.GetAsset;

public class GetAsset(
    IAssetRepository assetRepository
) : IRequestHandler<GetAssetInput, Output>
{
    private readonly IAssetRepository _assetRepository = assetRepository;

    public async Task<Output> Handle(GetAssetInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var asset = await _assetRepository.GetAsync(input.Id, cancellationToken);

        if (asset is null)
        {
            output.AddErrorMessage("Unable to find an asset for this id");
            return output;
        }

        output.AddResult(asset.MapToDto());
        return output;
    }
}
