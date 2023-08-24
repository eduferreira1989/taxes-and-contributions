namespace TAC.Person.Models.Exceptions;

[Serializable]
public class TaxNotAddedException : Exception
{
    public TaxNotAddedException() { }

    public TaxNotAddedException(Tax tax)
        : base($"Tax related to PaymentId: {tax.PaymentId} is not added to person of Id {tax.PersonId}")
    {

    }
}