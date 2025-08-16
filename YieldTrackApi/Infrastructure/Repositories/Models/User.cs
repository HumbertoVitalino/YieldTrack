using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Repositories.Models;

[Table("Users")]
public class User : Model
{
    [Required]
    public string Name { get; private set; } = default!;

    [Required]
    public string Email { get; private set; } = default!;

    [Required]
    public byte[] PasswordHash { get; private set; } = [];

    [Required]
    public byte[] PasswordSalt { get; private set; } = [];

    public ICollection<UserInvestment> Investments { get; private set; } = [];

    protected User() { }

    public User(
        Guid id,
        string name,
        string email,
        byte[] passwordHash,
        byte[] passwordSalt,
        DateTime createdAt,
        DateTime updatedAt        
    ) : base(id, createdAt, updatedAt)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }    
}
