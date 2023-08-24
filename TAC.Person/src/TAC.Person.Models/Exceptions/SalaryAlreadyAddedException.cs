namespace TAC.Person.Models.Exceptions;

[Serializable]
public class SalaryAlreadyAddedException : Exception
{
    public SalaryAlreadyAddedException() { }

    public SalaryAlreadyAddedException(Salary salary)
        : base($"Salary related to PaymentId: {salary.PaymentId} is already added to person of Id {salary.PersonId}")
    {

    }
}