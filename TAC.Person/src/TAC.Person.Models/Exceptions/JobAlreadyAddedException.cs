namespace TAC.Person.Models.Exceptions;

[Serializable]
public class JobAlreadyAddedException : Exception
{
    public JobAlreadyAddedException() { }

    public JobAlreadyAddedException(Job job)
        : base($"Job with CompanyId: {job.CompanyId}, started in {job.StartDate.Date} is already added to person of Id {job.PersonId}")
    {

    }
}