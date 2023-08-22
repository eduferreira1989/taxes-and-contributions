using System.Linq.Expressions;
using TAC.Common.Interfaces;
using TAC.Person.Interfaces;

namespace TAC.Person.Domains;

public class PersonService : IPersonService
{
    private readonly IRepository<Models.Person> _personRepository;

    public PersonService(IRepository<Models.Person> personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task CreateAsync(Models.Person person)
    {
        await _personRepository.CreateAsync(person);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _personRepository.RemoveAsync(id);
    }

    public async Task<IEnumerable<Models.Person>> GetAllAsync()
    {
        return await _personRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Models.Person>> GetAllAsync(Expression<Func<Models.Person, bool>> filter)
    {
        return await _personRepository.GetAllAsync(filter);
    }

    public async Task<Models.Person> GetAsync(Guid id)
    {
        return await _personRepository.GetAsync(id);
    }

    public async Task UpdateAsync(Models.Person person)
    {
        await _personRepository.UpdateAsync(person);
    }
}
