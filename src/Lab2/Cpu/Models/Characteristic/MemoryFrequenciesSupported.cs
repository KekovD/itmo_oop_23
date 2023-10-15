using Itmo.ObjectOrientedProgramming.Lab2.Other.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Ram.Models.Characteristic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models.Characteristic;

public abstract class MemoryFrequenciesSupported : ICharacteristic<int>, ICheckComponentValid
{
    public int Value { get; protected init; }
    public bool ComponentValid { get; private set; } = true;

    public void CheckComponentValid(ICheckComponentValid characteristic)
    {
        if (characteristic is RamMemoryFrequency ramMemoryFrequency)
        {
            ComponentValid = Value <= ramMemoryFrequency.Value;
        }
    }
}