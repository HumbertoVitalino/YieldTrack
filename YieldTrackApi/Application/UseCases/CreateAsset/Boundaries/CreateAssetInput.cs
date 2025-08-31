using Application.Commons;
using MediatR;

namespace Application.UseCases.CreateAsset.Boundaries;

public sealed record CreateAssetInput(
    string Code,
    string Name,
    string Issuer,
    decimal FaceValue,
    DateTime MaturityDate,
    decimal CurrentRate,
    string RateType
) : IRequest<Output>;
