using GMicroservices.Domain.Daos.Base;
using System.Linq.Expressions;

namespace GMicroservices.DataAccess.Abstractions.Repositories
{
    public interface IPersonRepository: IRepository<EntityBase>
    {
        //public Task<long> Create(Person person);
        //public new Task<IEnumerable<Person>> GetAllAsync(Expression<Func<Person, bool>> expression);
    }
}
