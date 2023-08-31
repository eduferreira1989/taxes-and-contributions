namespace TAC.Person.Models.Exceptions;

[Serializable]
public class PersonAlreadyAddedException : Exception
{
    public PersonAlreadyAddedException() { }

    public PersonAlreadyAddedException(string id)
        : base($"Person already added, Id: {id}")
    {

    }
}