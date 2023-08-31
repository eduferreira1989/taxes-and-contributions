using TAC.Person.Interfaces;
using TAC.Person.Models;
using TAC.Person.Models.Exceptions;

namespace TAC.Person.Domains;

public class PaymentService : IPaymentService
{
    private readonly IPersonService _personService;

    public PaymentService(IPersonService personService)
    {
        _personService = personService;
    }

    public async Task AddAsync(Payment payment)
    {
        var person = await _personService.GetAsync(payment.PersonId);
        if (person == null)
        {
            throw new PersonNotFoundException(payment.PersonId.ToString());
        }
        person.Payments.Add(payment);
        await _personService.UpdateAsync(payment.PersonId, person);
    }
}
