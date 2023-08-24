using TAC.Person.Models;

namespace TAC.Person.Interfaces;

public interface ITaxService
{
    Task AddAsync(Tax tax);

    Task PayAsync(Tax tax);
}
