using TAC.Common.Entities;

namespace TAC.Person.Models;

public class Contribution : IEntity
{
    public Guid Id { get; init; }

    public required Guid PersonId { get; set; }

    /// <summary>
    /// Payment that this contribution refers to
    /// </summary>
    public required Guid PaymentId { get; set; }

    public required double Value { get; set; }

    public required DateTimeOffset LimitDateOfPayment { get; set; }

    public required bool IsPaid { get; set; }
}
