using TAC.Person.Models.Dtos;

namespace TAC.Person.Models.Extensions;

public static class Extensions
{
    public static PersonJobDto AsDto(this Job job)
    {
        return new PersonJobDto(job.Id, job.PersonId, job.CompanyId, job.CompanyName, job.StartDate, job.EndDate, job.Salary);
    }

    public static PersonSalaryDto AsDto(this Salary salary)
    {
        return new PersonSalaryDto(salary.Id, salary.PersonId, salary.PaymentId, salary.GrossValue, salary.DateOfPayment);
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
        return new ReadPersonDto(person.Id, person.Name, person.DateOfBirth,
                                    person.Jobs.Select(j => j.AsDto()).ToList(), person.Salaries.Select(s => s.AsDto()).ToList(),
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

    public static Job AsDto(this PersonJobDto job)
    {
        return new Job
        {
            PersonId = job.PersonId,
            CompanyId = job.CompanyId,
            CompanyName = job.CompanyName,
            StartDate = job.StartDate,
            EndDate = job.EndDate,
            Salary = job.Salary
        };
    }

    public static Salary AsDto(this PersonSalaryDto salary)
    {
        return new Salary
        {
            PersonId = salary.PersonId,
            PaymentId = salary.PaymentId,
            GrossValue = salary.GrossValue,
            DateOfPayment = salary.DateOfPayment
        };
    }

    public static Tax AsDto(this PersonTaxDto tax)
    {
        return new Tax
        {
            PersonId = tax.PersonId,
            PaymentId = tax.PaymentId,
            Value = tax.Value,
            LimitDateOfPayment = tax.LimitDateOfPayment,
            IsPaid = tax.IsPaid
        };
    }

    public static Contribution AsDto(this PersonContributionDto contribution)
    {
        return new Contribution
        {
            PersonId = contribution.PersonId,
            PaymentId = contribution.PaymentId,
            Value = contribution.Value,
            LimitDateOfPayment = contribution.LimitDateOfPayment,
            IsPaid = contribution.IsPaid
        };
    }
}
