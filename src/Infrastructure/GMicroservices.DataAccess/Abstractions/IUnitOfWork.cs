using GMicroservices.Domain.Abstraction.DataAccess;

namespace GMicroservices.DataAccess.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity;

        void Commit();
    }
}
