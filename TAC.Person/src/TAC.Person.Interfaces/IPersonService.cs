using System.Linq.Expressions;

namespace TAC.Person.Interfaces;

public interface IPersonService
{
    Task<Models.Person> GetAsync(Guid id);

    Task<IEnumerable<Models.Person>> GetAllAsync();

    Task<IEnumerable<Models.Person>> GetAllAsync(Expression<Func<Models.Person, bool>> filter);

    Task CreateAsync(Models.Person person);

    Task UpdateAsync(Guid id, Models.Person person);

    Task DeleteAsync(Guid id);
}
