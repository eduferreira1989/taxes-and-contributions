using TAC.Common.Entities;

namespace TAC.Person.Models;

public class Salary : IEntity
{
    public Guid Id { get; init; }

    public required double GrossValue { get; set; }

    public required DateTimeOffset DateOfPayment { get; set; }
}
