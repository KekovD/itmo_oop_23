using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabException;

public class RepositoryNullException : Exception
{
    public RepositoryNullException()
        : base("Repository list is null.")
    {
    }

    public RepositoryNullException(string message)
        : base(message)
    {
    }

    public RepositoryNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}