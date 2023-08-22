using TAC.Person.Models;

namespace TAC.Person.Interfaces;

public interface ISalaryService
{
    Task ReceiveAsync(Salary salary);
}
