using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabException;

public class NameNotFoundException : Exception
{
    public NameNotFoundException()
        : base("Name not found in repository.")
    {
    }

    public NameNotFoundException(string message)
        : base(message)
    {
    }

    public NameNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}