namespace TAC.Person.Models.Exceptions;

[Serializable]
public class ContributionAlreadyAddedException : Exception
{
    public ContributionAlreadyAddedException() { }

    public ContributionAlreadyAddedException(Contribution contribution)
        : base($"Contribution related to PaymentId: {contribution.PaymentId} is already added to person of Id {contribution.PersonId}")
    {

    }
}