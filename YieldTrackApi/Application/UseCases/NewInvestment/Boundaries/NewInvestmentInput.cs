using Application.Commons;
using MediatR;

namespace Application.UseCases.NewInvestment.Boundaries;

public sealed record NewInvestmentInput(
    Guid AssetId,
    decimal Quantity,
    Guid UserId,
    DateTime PurchaseDate,
    DateTime DueDate
) : IRequest<Output>;
