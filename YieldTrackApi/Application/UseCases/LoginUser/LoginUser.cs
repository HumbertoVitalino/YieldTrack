using Application.Commons;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.UseCases.LoginUser.Boundaries;
using MediatR;

namespace Application.UseCases.LoginUser;

public sealed class LoginUser(
    IUserRepository userRepository,
    IPasswordService passwordService,
    IJwtService jwtService
) : IRequestHandler<LoginUserInput, Output>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordService _passwordService = passwordService;
    private readonly IJwtService _jwtService = jwtService;

    public async Task<Output> Handle(LoginUserInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var user = await _userRepository.GetAsync(input.Email, cancellationToken);

        if (user is null)
        {
            output.AddErrorMessage("User not found");
            return output;
        }

        bool isPasswordValid = await _passwordService.VerifyPasswordHash(input.Password, user.PasswordHash, user.PasswordSalt);

        if (!isPasswordValid)
        {
            output.AddErrorMessage("Invalid login attempt");
            return output;
        }
        var token = await _jwtService.GenerateToken(user.Id, user.Email);

        output.AddResult(token);
        return output;
    }
}
