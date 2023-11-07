using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class RenderNullException : Exception
{
    public RenderNullException()
        : base("Message is null.")
    {
    }

    public RenderNullException(string message)
        : base(message)
    {
    }

    public RenderNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}