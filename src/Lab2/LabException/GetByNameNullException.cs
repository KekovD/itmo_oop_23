using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabException;

public class GetByNameNullException : Exception
{
    public GetByNameNullException()
        : base("Name not found.")
    {
    }

    public GetByNameNullException(string message)
        : base(message)
    {
    }

    public GetByNameNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}