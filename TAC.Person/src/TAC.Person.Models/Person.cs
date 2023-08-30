using TAC.Common.Entities;

namespace TAC.Person.Models;

public class Person : IEntity
{
    public Person()
    {
        Taxes = new List<Tax>();
        Payments = new List<Payment>();
        Contributions = new List<Contribution>();
    }

    public Guid Id { get; init; }

    public required string Name { get; set; }

    public required DateTimeOffset DateOfBirth { get; set; }

    public IList<Payment> Payments { get; set; }

    public IList<Tax> Taxes { get; set; }

    public IList<Contribution> Contributions { get; set; }
}
