using TAC.Person.Interfaces;
using TAC.Person.Models;
using TAC.Person.Models.Exceptions;

namespace TAC.Person.Domains;

public class ContributionService : IContributionService
{
    private readonly IPersonService _personService;

    public ContributionService(IPersonService personService)
    {
        _personService = personService;
    }

    public async Task AddAsync(Contribution contribution)
    {
        var person = await _personService.GetAsync(contribution.PersonId);
        if (person == null)
        {
            throw new PersonNotFoundException(contribution.PersonId.ToString());
        }
        if (person.Contributions.Any(c => c.PaymentId == contribution.PaymentId))
        {
            throw new ContributionAlreadyAddedException(contribution);
        }
        person.Contributions.Add(contribution);
        await _personService.UpdateAsync(contribution.PersonId, person);
    }

    public async Task PayAsync(Contribution contribution)
    {
        var person = await _personService.GetAsync(contribution.PersonId);
        if (person == null)
        {
            throw new PersonNotFoundException(contribution.PersonId.ToString());
        }
        var contributionItem = person.Contributions.SingleOrDefault(c => c.Id == contribution.Id);
        if (contributionItem == null)
        {
            throw new ContributionNotAddedException(contribution);
        }

        contributionItem.Value = contribution.Value;
        contributionItem.IsPaid = contribution.IsPaid;

        await _personService.UpdateAsync(contribution.PersonId, person);
    }
}
