using Application.Commons;
using MediatR;

namespace Application.UseCases.CreateUser.Boundaries;

public sealed record CreateUserInput(
    string Name,
    string Email,
    string Password,
    string Confirmation
) : IRequest<Output>;
