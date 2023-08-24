using TAC.Person.Interfaces;
using TAC.Person.Models;
using TAC.Person.Models.Exceptions;

namespace TAC.Person.Domains;

public class SalaryService : ISalaryService
{
    private readonly IPersonService _personService;

    public SalaryService(IPersonService personService)
    {
        _personService = personService;
    }

    public async Task AddAsync(Salary salary)
    {
        var person = await _personService.GetAsync(salary.PersonId);
        if (person == null)
        {
            throw new PersonNotFoundException(salary.PersonId.ToString());
        }
        if (person.Salaries.Any(s => s.PaymentId == salary.PaymentId))
        {
            throw new SalaryAlreadyAddedException(salary);
        }
        person.Salaries.Add(salary);
        await _personService.UpdateAsync(person);
    }
}
