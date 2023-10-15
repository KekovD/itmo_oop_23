namespace Itmo.ObjectOrientedProgramming.Lab2.Other.Models.Characteristic;

public abstract class PowerConsumption : ICharacteristic<int>
{
    public int Value { get; protected init; }
}