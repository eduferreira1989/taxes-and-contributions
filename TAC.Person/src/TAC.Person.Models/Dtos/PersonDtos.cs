namespace TAC.Person.Models.Dtos;

public record CreatePersonDto(Guid Id, string Name, string VatNumber, string SocialSecurityNumber, DateTimeOffset DateOfBirth);

public record UpdatePersonDto(Guid Id, string Name, string VatNumber, string SocialSecurityNumber, DateTimeOffset DateOfBirth);

public record ReadPersonDto(Guid Id, string Name, string VatNumber, string SocialSecurityNumber, DateTimeOffset DateOfBirth,
                            IEnumerable<PersonJobDto> Jobs, IEnumerable<PersonSalaryDto> Salaries, IEnumerable<PersonTaxDto> Taxes, IEnumerable<PersonContributionDto> Contributions);

public record PersonJobDto(Guid Id, Guid PersonId, Guid CompanyId, string CompanyName, DateTimeOffset StartDate, DateTimeOffset? EndDate, double Salary);

public record PersonSalaryDto(Guid Id, Guid PersonId, Guid PaymentId, double GrossValue, DateTimeOffset DateOfPayment);

public record PersonTaxDto(Guid Id, Guid PersonId, Guid PaymentId, double Value, DateTimeOffset LimitDateOfPayment, bool IsPaid);

public record PersonContributionDto(Guid Id, Guid PersonId, Guid PaymentId, double Value, DateTimeOffset LimitDateOfPayment, bool IsPaid);