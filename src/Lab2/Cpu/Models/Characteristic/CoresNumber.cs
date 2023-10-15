using Itmo.ObjectOrientedProgramming.Lab2.Other.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models.Characteristic;

public abstract class CoresNumber : ICharacteristic<int>
{
    public int Value { get; protected init; }
}