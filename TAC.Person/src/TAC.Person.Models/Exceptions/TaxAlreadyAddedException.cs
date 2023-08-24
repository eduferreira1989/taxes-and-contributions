namespace TAC.Person.Models.Exceptions;

[Serializable]
public class TaxAlreadyAddedException : Exception
{
    public TaxAlreadyAddedException() { }

    public TaxAlreadyAddedException(Tax tax)
        : base($"Tax related to PaymentId: {tax.PaymentId} is already added to person of Id {tax.PersonId}")
    {

    }
}