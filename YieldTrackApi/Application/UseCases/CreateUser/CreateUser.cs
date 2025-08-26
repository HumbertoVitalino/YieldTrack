using Application.Commons;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.UseCases.CreateUser.Boundaries;
using MediatR;

namespace Application.UseCases.CreateUser;

public class CreateUser(
    IUserRepository userRepository,
    IPasswordService passwordService
) : IRequestHandler<CreateUserInput, Output>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordService _passwordService = passwordService;

    public async Task<Output> Handle(CreateUserInput input, CancellationToken cancellationToken)
    {
        Output output = new();

        var user = await _userRepository.GetAsync(input.Email, cancellationToken);

        if (user is not null)
        {
            output.AddErrorMessage("User already exists!");
            return output;
        }

        var (passwordHash, passwordSalt) = await _passwordService.CreatePasswordHash(input.Password);

        await _userRepository.InsertAsync(input.MapToDomain(passwordHash, passwordSalt), cancellationToken);

        var saved = await _userRepository.UnitOfWork.CommitAsync(cancellationToken);

        if (!saved)
        {
            output.AddMessage("Unable to save user");
            return output;
        }

        return output;
    }
}
