using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.LabException;

public class PartOfShipNullException : Exception
{
    public PartOfShipNullException()
        : base("Ship's part is null")
    {
    }

    public PartOfShipNullException(string message)
        : base(message)
    {
    }

    public PartOfShipNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}