using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class ContextNullException : Exception
{
    public ContextNullException()
        : base("Property in context is null.")
    {
    }

    public ContextNullException(string message)
        : base(message)
    {
    }

    public ContextNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}