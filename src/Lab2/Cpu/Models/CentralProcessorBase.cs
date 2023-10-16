namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;

public abstract class CentralProcessorBase
{
    public int MemoryFrequencies { get; private init; }
    public int CoreFrequency { get; private init; }
    public int CoresNumber { get; private init; }
    public bool IntegratedVideoCore { get; private init; }
    public int ThermalDesignPower { get; private init; }
    public int PowerConsumption { get; protected init; }
}