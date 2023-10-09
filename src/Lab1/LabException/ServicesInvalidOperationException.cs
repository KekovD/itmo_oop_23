using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.LabException;

public class ServicesInvalidOperationException : Exception
{
    public ServicesInvalidOperationException()
        : base("Operation behavior is unknown")
    {
    }

    public ServicesInvalidOperationException(string message)
        : base(message)
    {
    }

    public ServicesInvalidOperationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}