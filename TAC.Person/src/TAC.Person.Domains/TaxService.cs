using TAC.Person.Interfaces;
using TAC.Person.Models;
using TAC.Person.Models.Exceptions;

namespace TAC.Person.Domains;

public class TaxService : ITaxService
{
    private readonly IPersonService _personService;

    public TaxService(IPersonService personService)
    {
        _personService = personService;
    }

    public async Task AddAsync(Tax tax)
    {
        var person = await _personService.GetAsync(tax.PersonId);
        if (person == null)
        {
            throw new PersonNotFoundException(tax.PersonId.ToString());
        }
        if (person.Taxes.Any(t => t.PaymentId == tax.PaymentId))
        {
            throw new TaxAlreadyAddedException(tax);
        }
        person.Taxes.Add(tax);
        await _personService.UpdateAsync(person);
    }

    public async Task PayAsync(Tax tax)
    {
        var person = await _personService.GetAsync(tax.PersonId);
        if (person == null)
        {
            throw new PersonNotFoundException(tax.PersonId.ToString());
        }
        var taxItem = person.Taxes.SingleOrDefault(t => t.PaymentId == tax.PaymentId);
        if (taxItem == null)
        {
            throw new TaxNotAddedException(tax);
        }

        taxItem.IsPaid = tax.IsPaid;

        await _personService.UpdateAsync(person);
    }
}
