using Application.Commons;
using MediatR;

namespace Application.UseCases.GetAssets.Boundaries;

public sealed record GetAssetsInput() : IRequest<Output>;
