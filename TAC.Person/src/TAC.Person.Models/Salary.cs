using TAC.Common.Entities;

namespace TAC.Person.Models;

public class Salary : IEntity
{
    public Guid Id { get; init; }

    public required Guid PersonId { get; set; }

    /// <summary>
    /// Payment that this salary refers to
    /// </summary>
    public required Guid PaymentId { get; set; }

    public required double GrossValue { get; set; }

    public required DateTimeOffset DateOfPayment { get; set; }
}
