using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.LabException;

public class BuilderNullException : Exception
{
    public BuilderNullException()
        : base("Property is null.")
    {
    }

    public BuilderNullException(string message)
        : base(message)
    {
    }

    public BuilderNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}