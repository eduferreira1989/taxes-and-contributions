using TAC.Common.Entities;

namespace TAC.Person.Models;

public class Person : IEntity
{
    public Person()
    {
        Jobs = new List<Job>();
        Taxes = new List<Tax>();
        Salaries = new List<Salary>();
        Contributions = new List<Contribution>();
    }

    public Guid Id { get; init; }

    public required string Name { get; set; }

    public required string VatNumber { get; set; }

    public required string SocialSecurityNumber { get; set; }

    public required DateTimeOffset DateOfBirth { get; set; }

    public IList<Job> Jobs { get; set; }

    public IList<Salary> Salaries { get; set; }

    public IList<Tax> Taxes { get; set; }

    public IList<Contribution> Contributions { get; set; }
}
