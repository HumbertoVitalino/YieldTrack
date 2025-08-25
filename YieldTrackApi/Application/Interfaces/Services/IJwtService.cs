namespace Application.Interfaces.Services;

public interface IJwtService
{
    Task<string> GenerateToken(Guid userId, string email);
}
