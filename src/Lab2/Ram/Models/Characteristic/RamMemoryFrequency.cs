using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models.Characteristic;
using Itmo.ObjectOrientedProgramming.Lab2.Other.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Models.Characteristic;

public abstract class RamMemoryFrequency : ICheckComponentValid
{
    public int Value { get; protected init; }
    public bool ComponentValid { get; private set; } = true;

    public void CheckComponentValid(ICheckComponentValid characteristic)
    {
        if (characteristic is MemoryFrequenciesSupported cpuMemoryFrequenciesSupported)
            ComponentValid = Value >= cpuMemoryFrequenciesSupported.Value;
    }
}