using Domain;

namespace Application.Interfaces.Repositories;

public interface IRepository<T> where T : Entity
{
    IUnitOfWork UnitOfWork { get; }
}
