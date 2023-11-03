using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.LabException;

public class ProxyNullException : Exception
{
    public ProxyNullException()
        : base("Property is null.")
    {
    }

    public ProxyNullException(string message)
        : base(message)
    {
    }

    public ProxyNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}