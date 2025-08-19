using Domain;

namespace Application.UseCases.CreateUser.Boundaries;

public static class CreateUserMapper
{
    public static User MapToDomain(this CreateUserInput input, byte[] passwordHash, byte[] passwordSalt) =>
        new(
            Guid.NewGuid(),
            input.Name,
            input.Email,
            passwordHash,
            passwordSalt
        );
}
