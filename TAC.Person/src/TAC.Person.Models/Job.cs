using TAC.Common.Entities;

namespace TAC.Person.Models;

public class Job : IEntity
{
    public Guid Id { get; init; }

    public required Guid CompanyId { get; set; }

    public required string CompanyName { get; set; }

    public required DateTimeOffset StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public required double Salary { get; set; }
}
