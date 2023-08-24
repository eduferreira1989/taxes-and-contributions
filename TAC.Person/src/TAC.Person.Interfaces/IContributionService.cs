using TAC.Person.Models;

namespace TAC.Person.Interfaces;

public interface IContributionService
{
    Task AddAsync(Contribution contribution);

    Task PayAsync(Contribution contribution);
}
