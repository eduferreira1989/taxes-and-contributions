using TAC.Common.Entities;

namespace TAC.Finance.Models;

public class Person : IEntity
{
    public Guid Id { get; init; }

    public required string Name { get; set; }

    public required DateTimeOffset DateOfBirth { get; set; }
}
