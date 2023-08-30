namespace TAC.Person.Models.Dtos;

public record CreatePersonDto(Guid Id, string Name, DateTimeOffset DateOfBirth);

public record UpdatePersonDto(Guid Id, string Name, DateTimeOffset DateOfBirth);

public record ReadPersonDto(Guid Id, string Name, DateTimeOffset DateOfBirth, IEnumerable<PersonPaymentDto> Payments,
                            IEnumerable<PersonTaxDto> Taxes, IEnumerable<PersonContributionDto> Contributions);

public record PersonPaymentDto(Guid Id, Guid PersonId, double GrossValue, DateTimeOffset DateOfPayment);

public record PersonTaxDto(Guid Id, Guid PersonId, Guid PaymentId, double Value, DateTimeOffset LimitDateOfPayment, bool IsPaid);

public record PersonContributionDto(Guid Id, Guid PersonId, Guid PaymentId, double Value, DateTimeOffset LimitDateOfPayment, bool IsPaid);