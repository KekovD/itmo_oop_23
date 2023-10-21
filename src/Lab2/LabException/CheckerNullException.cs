using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabException;

public class CheckerNullException : Exception
{
    public CheckerNullException()
        : base("Property is null.")
    {
    }

    public CheckerNullException(string message)
        : base(message)
    {
    }

    public CheckerNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}