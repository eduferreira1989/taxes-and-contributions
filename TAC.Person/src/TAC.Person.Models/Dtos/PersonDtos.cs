namespace TAC.Person.Models.Dtos;

public record CreatePersonDto(Guid Id, string Name, DateTimeOffset DateOfBirth);

public record UpdatePersonDto(Guid Id, string Name, DateTimeOffset DateOfBirth);

public record ReadPersonDto(Guid Id, string Name, DateTimeOffset DateOfBirth, IEnumerable<ReadPersonPaymentDto> Payments,
                            IEnumerable<ReadPersonTaxDto> Taxes, IEnumerable<ReadPersonContributionDto> Contributions);

public record CreatePersonPaymentDto(Guid PersonId, double GrossValue, DateTimeOffset DateOfPayment);

public record UpdatePersonPaymentDto(Guid Id, Guid PersonId, double GrossValue, DateTimeOffset DateOfPayment);

public record ReadPersonPaymentDto(Guid Id, Guid PersonId, double GrossValue, DateTimeOffset DateOfPayment);

public record CreatePersonTaxDto(Guid PersonId, Guid PaymentId, double Value, DateTimeOffset LimitDateOfPayment, bool IsPaid);

public record PayPersonTaxDto(Guid Id, Guid PersonId, Guid PaymentId, double Value, DateTimeOffset LimitDateOfPayment, bool IsPaid);

public record ReadPersonTaxDto(Guid Id, Guid PersonId, Guid PaymentId, double Value, DateTimeOffset LimitDateOfPayment, bool IsPaid);

public record CreatePersonContributionDto(Guid PersonId, Guid PaymentId, double Value, DateTimeOffset LimitDateOfPayment, bool IsPaid);

public record PayPersonContributionDto(Guid Id, Guid PersonId, Guid PaymentId, double Value, DateTimeOffset LimitDateOfPayment, bool IsPaid);

public record ReadPersonContributionDto(Guid Id, Guid PersonId, Guid PaymentId, double Value, DateTimeOffset LimitDateOfPayment, bool IsPaid);