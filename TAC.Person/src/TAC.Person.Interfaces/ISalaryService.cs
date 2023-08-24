using TAC.Person.Models;

namespace TAC.Person.Interfaces;

public interface ISalaryService
{
    Task AddAsync(Salary salary);
}
