using Application.Commons;
using Application.Interfaces.Repositories;
using Application.UseCases.NewInvestment.Boundaries;
using MediatR;

namespace Application.UseCases.NewInvestment;

public sealed class NewInvestment(
    IInvestmentRepository investorRepository,
    IAssetRepository assetRepository,
) : IRequestHandler<NewInvestmentInput, Output>
{
    private readonly IInvestmentRepository _investmentRepository = investorRepository;
    private readonly IAssetRepository _assetRepository = assetRepository;

    public async Task<Output> Handle(NewInvestmentInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var asset = await _assetRepository.GetAsync(input.AssetId, cancellationToken);
    }
}
