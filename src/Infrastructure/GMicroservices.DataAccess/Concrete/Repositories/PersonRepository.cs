using Microsoft.EntityFrameworkCore;
using GMicroservices.DataAccess.Abstractions;
using GMicroservices.DataAccess.Abstractions.Repositories;
using GMicroservices.DataAccess.Persistence.DBContexts;
using GMicroservices.DataAccess.Persistence.Repositories;
using GMicroservices.Domain.Daos.Main;
using System.Linq.Expressions;

namespace GMicroservices.DataAccess.Concrete.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }


        public new async Task<IEnumerable<Person>> GetAllAsync(Expression<Func<Person, bool>> expression)
        {
            return await _appDbContext.GetDbSet<Person>().Where(expression).Include(x => x.Address).ToListAsync();
        }
        public Task<long> Create(Person person)
        {
            return Task<long>.Run(() =>
            {
                return (long)1;
            });
        }
    }
}
