using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabException;

public class CharacteristicNullException : Exception
{
    public CharacteristicNullException()
        : base("Characteristic is null")
    {
    }

    public CharacteristicNullException(string message)
        : base(message)
    {
    }

    public CharacteristicNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}