using TAC.Common.Entities;

namespace TAC.Finance.Models;

public class Person : IEntity
{
    public Guid Id { get; init; }

    public required Guid PersonId { get; set; }

    public required double GrossValue { get; set; }

    public required DateTimeOffset DateOfPayment { get; set; }
}
