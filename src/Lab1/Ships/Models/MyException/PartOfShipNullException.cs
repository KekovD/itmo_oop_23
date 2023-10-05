using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.MyException;

public class PartOfShipNullException : Exception
{
    public PartOfShipNullException()
        : base("Part is null")
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