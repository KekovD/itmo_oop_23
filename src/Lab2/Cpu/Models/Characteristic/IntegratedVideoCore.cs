using Itmo.ObjectOrientedProgramming.Lab2.Other.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models.Characteristic;

public class IntegratedVideoCore : ICharacteristic<bool>
{
    public bool Value { get; protected init; }
}