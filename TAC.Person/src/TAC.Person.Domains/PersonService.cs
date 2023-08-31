using System.Linq.Expressions;
using TAC.Common.Interfaces;
using TAC.Person.Interfaces;
using TAC.Person.Models.Exceptions;

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
        var existingPerson = await _personRepository.GetAllAsync(p => p.Name == person.Name && p.DateOfBirth == person.DateOfBirth).ConfigureAwait(false);
        if (existingPerson.Any())
        {
            throw new PersonAlreadyAddedException(existingPerson.First().Id.ToString());
        }

        await _personRepository.CreateAsync(person).ConfigureAwait(false);
    }

    public async Task DeleteAsync(Guid id)
    {
        var existingPerson = await _personRepository.GetAsync(id).ConfigureAwait(false);
        if (existingPerson == null)
        {
            throw new PersonNotFoundException(id.ToString());
        }

        await _personRepository.RemoveAsync(id).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Models.Person>> GetAllAsync()
    {
        return await _personRepository.GetAllAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Models.Person>> GetAllAsync(Expression<Func<Models.Person, bool>> filter)
    {
        return await _personRepository.GetAllAsync(filter).ConfigureAwait(false);
    }

    public async Task<Models.Person> GetAsync(Guid id)
    {
        return await _personRepository.GetAsync(id).ConfigureAwait(false);
    }

    public async Task UpdateAsync(Guid id, Models.Person person)
    {
        var existingPerson = await _personRepository.GetAsync(id).ConfigureAwait(false);
        if (existingPerson == null)
        {
            throw new PersonNotFoundException(id.ToString());
        }

        await _personRepository.UpdateAsync(person).ConfigureAwait(false);
    }
}
