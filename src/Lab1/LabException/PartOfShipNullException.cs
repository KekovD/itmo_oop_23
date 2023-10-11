using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.LabException;

/// <summary>
/// This exception is needed because the properties in "ShipsBase" are nullable. And their types are abstract classes.
/// </summary>
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