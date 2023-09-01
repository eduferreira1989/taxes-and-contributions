using TAC.Person.Models.Dtos;

namespace TAC.Person.Models.Extensions;

public static class Extensions
{
    public static PersonPaymentDto AsDto(this Payment payment)
    {
        return new PersonPaymentDto(payment.Id, payment.PersonId, payment.GrossValue, payment.DateOfPayment);
    }

    public static PersonTaxDto AsDto(this Tax tax)
    {
        return new PersonTaxDto(tax.Id, tax.PersonId, tax.PaymentId, tax.Value, tax.LimitDateOfPayment, tax.IsPaid);
    }

    public static PersonContributionDto AsDto(this Contribution contribution)
    {
        return new PersonContributionDto(contribution.Id, contribution.PersonId, contribution.PaymentId, contribution.Value, contribution.LimitDateOfPayment, contribution.IsPaid);
    }

    public static ReadPersonDto AsDto(this Person person)
    {
        return new ReadPersonDto(person.Id, person.Name, person.DateOfBirth, person.Payments.Select(p => p.AsDto()).ToList(),
                                    person.Taxes.Select(t => t.AsDto()).ToList(), person.Contributions.Select(c => c.AsDto()).ToList());
    }

    public static Person AsPerson(this CreatePersonDto createPersonDto)
    {
        return new Person()
        {
            Name = createPersonDto.Name,
            DateOfBirth = createPersonDto.DateOfBirth
        };
    }

    public static Person AsPerson(this UpdatePersonDto updatePersonDto)
    {
        return new Person()
        {
            Name = updatePersonDto.Name,
            DateOfBirth = updatePersonDto.DateOfBirth
        };
    }

    public static Payment AsPayment(this PersonPaymentDto paymentDto)
    {
        return new Payment
        {
            PersonId = paymentDto.PersonId,
            GrossValue = paymentDto.GrossValue,
            DateOfPayment = paymentDto.DateOfPayment
        };
    }

    public static Tax AsTax(this PersonTaxDto taxDto)
    {
        return new Tax
        {
            PersonId = taxDto.PersonId,
            PaymentId = taxDto.PaymentId,
            LimitDateOfPayment = taxDto.LimitDateOfPayment,
            Value = taxDto.Value,
            IsPaid = taxDto.IsPaid
        };
    }

    public static Contribution AsContribution(this PersonContributionDto contributionDto)
    {
        return new Contribution
        {
            PersonId = contributionDto.PersonId,
            PaymentId = contributionDto.PaymentId,
            LimitDateOfPayment = contributionDto.LimitDateOfPayment,
            Value = contributionDto.Value,
            IsPaid = contributionDto.IsPaid
        };
    }
}
