namespace TAC.Person.Models.Exceptions;

[Serializable]
public class JobNotAddedException : Exception
{
    public JobNotAddedException() { }

    public JobNotAddedException(Job job)
        : base($"Job with CompanyId: {job.CompanyId}, started in {job.StartDate.Date} is not added to person of Id {job.PersonId}")
    {

    }
}