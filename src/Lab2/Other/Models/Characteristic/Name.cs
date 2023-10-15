namespace Itmo.ObjectOrientedProgramming.Lab2.Other.Models.Characteristic;

public abstract class Name : ICharacteristic<string?>
{
    public string? Value { get; protected init; }
}