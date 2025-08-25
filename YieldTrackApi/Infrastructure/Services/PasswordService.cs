using Application.Interfaces.Services;
using System.Security.Cryptography;

namespace Infrastructure.Services;

public class PasswordService : IPasswordService
{
    private const int Iterations = 10000;
    private const int SaltSize = 16;
    private const int HashSize = 32;

    public async Task<(byte[] passwordHash, byte[] passwordSalt)> CreatePasswordHash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            HashSize
        );

        await Task.Yield();

        return (hash, salt);
    }

    public async Task<bool> VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
            password,
            storedSalt,
            Iterations,
            HashAlgorithmName.SHA256,
            HashSize
        );

        await Task.Yield();

        return CryptographicOperations.FixedTimeEquals(hashToCompare, storedHash);
    }
}
