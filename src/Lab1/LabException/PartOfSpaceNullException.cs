using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.LabException;

public class PartOfSpaceNullException : Exception
{
    public PartOfSpaceNullException()
        : base("Space's part is null")
    {
    }

    public PartOfSpaceNullException(string message)
        : base(message)
    {
    }

    public PartOfSpaceNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}