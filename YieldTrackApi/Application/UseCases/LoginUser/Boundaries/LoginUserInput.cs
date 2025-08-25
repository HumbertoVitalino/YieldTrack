using Application.Commons;
using MediatR;

namespace Application.UseCases.LoginUser.Boundaries;

public sealed record LoginUserInput(
    string Email,
    string Password
) : IRequest<Output>;
