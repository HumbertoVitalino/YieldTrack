namespace Infrastructure.Repositories.Mappers;

public static class DomainMappers
{
    public static Domain.User MapToDomain(this Models.User model) =>
        new(
            model.Id,
            model.Name,
            model.Email,
            model.PasswordHash,
            model.PasswordSalt
        );
}
