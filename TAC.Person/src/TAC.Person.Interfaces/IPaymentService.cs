using TAC.Person.Models;

namespace TAC.Person.Interfaces;

public interface IPaymentService
{
    Task AddAsync(Payment payment);
}
