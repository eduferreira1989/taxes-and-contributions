using TAC.Person.Interfaces;
using TAC.Person.Models;
using TAC.Person.Models.Exceptions;

namespace TAC.Person.Domains;

public class JobService : IJobService
{
    private readonly IPersonService _personService;

    public JobService(IPersonService personService)
    {
        _personService = personService;
    }

    public async Task AddAsync(Job job)
    {
        var person = await _personService.GetAsync(job.PersonId);
        if (person == null)
        {
            throw new PersonNotFoundException(job.PersonId.ToString());
        }
        if (person.Jobs.Any(j => j.CompanyId == job.CompanyId && j.StartDate == job.StartDate))
        {
            throw new JobAlreadyAddedException(job);
        }
        person.Jobs.Add(job);
        await _personService.UpdateAsync(person);
    }

    public async Task UpdateAsync(Job job)
    {
        var person = await _personService.GetAsync(job.PersonId);
        if (person == null)
        {
            throw new PersonNotFoundException(job.PersonId.ToString());
        }
        var jobItem = person.Jobs.SingleOrDefault(j => j.CompanyId == job.CompanyId && j.StartDate == job.StartDate);
        if (jobItem == null)
        {
            throw new JobNotAddedException(job);
        }

        jobItem.Salary = job.Salary;
        jobItem.EndDate = job.EndDate;

        await _personService.UpdateAsync(person);
    }
}
