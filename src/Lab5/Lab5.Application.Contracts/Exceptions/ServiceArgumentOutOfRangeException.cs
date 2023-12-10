namespace Workshop5.Application.Contracts.Exceptions;

public class ServiceArgumentOutOfRangeException : ArgumentOutOfRangeException
{
    public ServiceArgumentOutOfRangeException()
    {
    }

    public ServiceArgumentOutOfRangeException(string unknownValueMessage)
        : base(unknownValueMessage)
    {
    }

    public ServiceArgumentOutOfRangeException(string unknownValueMessage, Exception innerException)
        : base(unknownValueMessage, innerException)
    {
    }
}