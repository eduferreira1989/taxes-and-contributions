using TAC.Common.Entities;

namespace TAC.Person.Models;

public class Payment : IEntity
{
    public Guid Id { get; init; }

    public required Guid PersonId { get; set; }

    public required double GrossValue { get; set; }

    public required DateTimeOffset DateOfPayment { get; set; }
}
