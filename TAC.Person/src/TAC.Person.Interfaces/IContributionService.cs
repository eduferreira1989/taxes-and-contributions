using TAC.Person.Models;

namespace TAC.Person.Interfaces;

public interface IContributionService
{
    Task AssignAsync(Contribution contribution);

    Task PayAsync(Contribution contribution);
}
