using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabException;

public class CrateNullException : Exception
{
    public CrateNullException()
        : base("Property is null.")
    {
    }

    public CrateNullException(string message)
        : base(message)
    {
    }

    public CrateNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}