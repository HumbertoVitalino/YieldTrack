namespace Domain;

public class User(
    Guid? id,
    string name,
    string email,
    byte[] passwordHash,
    byte[] passwordSalt
) : Entity(id)
{
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public byte[] PasswordHash { get; private set; } = passwordHash;
    public byte[] PasswordSalt { get; private set; } = passwordSalt;
    private List<UserInvestment> _investments = [];
    public IReadOnlyCollection<UserInvestment> Investments => _investments.AsReadOnly();
}
