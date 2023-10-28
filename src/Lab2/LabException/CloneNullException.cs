using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabException;

public class CloneNullException : Exception
{
    public CloneNullException()
        : base("Property is null.")
    {
    }

    public CloneNullException(string message)
        : base(message)
    {
    }

    public CloneNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}