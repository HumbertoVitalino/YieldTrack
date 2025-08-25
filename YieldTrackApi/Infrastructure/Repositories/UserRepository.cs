using Application.Interfaces.Repositories;
using Domain;
using Infrastructure.Repositories.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository(YieldTrackContext context) : Repository<User>(context), IUserRepository
{
    public async Task<Domain.User?> GetAsync(string email, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.Equals(email), cancellationToken);

        return user?.MapToDomain();
    }

    public async Task InsertAsync(User user, CancellationToken cancellationToken)
    {
        await _context.AddAsync(user.MapToModel(), cancellationToken);
    }
}
