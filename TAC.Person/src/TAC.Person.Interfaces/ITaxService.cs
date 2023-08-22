using TAC.Person.Models;

namespace TAC.Person.Interfaces;

public interface ITaxService
{
    Task AssignAsync(Tax tax);

    Task PayAsync(Tax tax);
}
