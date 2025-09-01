using Application.Commons;
using MediatR;

namespace Application.UseCases.GetAsset.Boundaries;

public sealed record GetAssetInput(
    Guid Id
) : IRequest<Output>;
