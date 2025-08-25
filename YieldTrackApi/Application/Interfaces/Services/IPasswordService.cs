namespace Application.Interfaces.Services;

public interface IPasswordService
{
    Task<(byte[] passwordHash, byte[] passwordSalt)> CreatePasswordHash(string password);
    Task<bool>VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
}
