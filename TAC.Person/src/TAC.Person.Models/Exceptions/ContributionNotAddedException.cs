namespace TAC.Person.Models.Exceptions;

[Serializable]
public class ContributionNotAddedException : Exception
{
    public ContributionNotAddedException() { }

    public ContributionNotAddedException(Contribution contribution)
        : base($"Contribution related to PaymentId: {contribution.PaymentId} is not added to person of Id {contribution.PersonId}")
    {

    }
}