using Application.Interfaces.Repositories;
using Domain;

namespace Infrastructure.Repositories;

public abstract class Repository<T>(YieldTrackContext context) : IRepository<T> where T : Entity
{
    protected readonly YieldTrackContext _context = context;
    public IUnitOfWork UnitOfWork => _context;
}
