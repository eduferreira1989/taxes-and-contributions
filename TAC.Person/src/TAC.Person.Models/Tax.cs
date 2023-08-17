using TAC.Common.Entities;

namespace TAC.Person.Models;

public class Tax : IEntity
{
    public Guid Id { get; init; }

    /// <summary>
    /// Payment that this tax refers to
    /// </summary>
    public required Guid PaymentId { get; set; }

    public required double Value { get; set; }

    public required DateTimeOffset LimitDateOfPayment { get; set; }

    public required bool IsPaid { get; set; }
}
