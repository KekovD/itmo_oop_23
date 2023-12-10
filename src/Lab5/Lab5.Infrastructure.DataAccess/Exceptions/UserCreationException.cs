namespace Lab5.Infrastructure.DataAccess.Exceptions;

public class UserCreationException : NullReferenceException
{
    public UserCreationException()
        : base("User could not be found.")
    {
    }

    public UserCreationException(string message)
        : base(message)
    {
    }

    public UserCreationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}