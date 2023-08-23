namespace TAC.Person.Models.Exceptions;

[Serializable]
public class PersonNotFoundException : Exception
{
    public PersonNotFoundException() { }

    public PersonNotFoundException(string id)
        : base($"Person not found, Id: {id}")
    {

    }
}