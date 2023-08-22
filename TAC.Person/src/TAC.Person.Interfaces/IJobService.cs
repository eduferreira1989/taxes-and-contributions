using TAC.Person.Models;

namespace TAC.Person.Interfaces;

public interface IJobService
{
    Task AddAsync(Job job);

    Task UpdateAsync(Job job);
}
