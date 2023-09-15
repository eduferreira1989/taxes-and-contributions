namespace TAC.Finance.Models.Dtos;

public record CreatePersonDto(Guid Id, string Name, DateTimeOffset DateOfBirth);

public record UpdatePersonDto(Guid Id, string Name, DateTimeOffset DateOfBirth);

public record CreatePaymentDto(Guid Id, Guid PersonId, double GrossValue, DateTimeOffset DateOfPayment);

public record CreateTaxDto(Guid PersonId, Guid PaymentId, double Value, DateTimeOffset LimitDateOfPayment, bool IsPaid);

public record PayTaxDto(Guid Id, Guid PersonId, double Value, bool IsPaid);

public record ReadTaxDto(Guid Id, Guid PersonId, Guid PaymentId, double Value, DateTimeOffset LimitDateOfPayment, bool IsPaid);