using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models.Characteristic;
using Itmo.ObjectOrientedProgramming.Lab2.Other.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.CpuCoolingSystem.Models.Characteristic;

public abstract class CoolingSystemThermalDesignPower : ICharacteristic<int>, ICheckComponentValid
{
    public int Value { get; protected init; }
    public bool ComponentValid { get; private set; } = true;

    public void CheckComponentValid(ICheckComponentValid characteristic)
    {
        if (characteristic is CentralProcessorThermalDesignPower cpuThermalDesignPower)
        {
            ComponentValid = Value >= cpuThermalDesignPower.Value;
        }
    }
}