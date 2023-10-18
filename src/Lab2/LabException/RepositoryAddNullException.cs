using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabException;

public class RepositoryAddNullException : Exception
{
    public RepositoryAddNullException()
        : base("New item parameter is null.")
    {
    }

    public RepositoryAddNullException(string message)
        : base(message)
    {
    }

    public RepositoryAddNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}