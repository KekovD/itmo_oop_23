using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabException;

public class IncorrectArgumentComparisonException : Exception
{
    public IncorrectArgumentComparisonException()
        : base("Passed an invalid argument for comparison")
    {
    }

    public IncorrectArgumentComparisonException(string message)
        : base(message)
    {
    }

    public IncorrectArgumentComparisonException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}