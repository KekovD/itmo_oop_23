using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.MyException;

public class DifferentLengthCollectionsWhenCreatingSpaceException : Exception
{
    public DifferentLengthCollectionsWhenCreatingSpaceException()
        : base("Different length collections when creating space")
    {
    }

    public DifferentLengthCollectionsWhenCreatingSpaceException(string message)
        : base(message)
    {
    }

    public DifferentLengthCollectionsWhenCreatingSpaceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}