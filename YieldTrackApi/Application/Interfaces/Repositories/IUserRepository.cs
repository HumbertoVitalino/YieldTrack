using Domain;

namespace Application.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetAsync(string email, CancellationToken cancellationToken);
    Task InsertAsync(User user, CancellationToken cancellationToken);
}
