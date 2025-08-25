namespace Infrastructure.Repositories.Mappers;

public static class ModelMappers
{
    public static Models.User MapToModel(this Domain.User user) =>
        new(
            user.Id,
            user.Name,
            user.Email,
            user.PasswordHash,
            user.PasswordSalt,
            user.CreatedAt,
            user.UpdatedAt
        );
}
