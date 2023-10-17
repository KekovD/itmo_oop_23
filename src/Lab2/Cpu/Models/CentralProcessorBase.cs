namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;

public abstract class CentralProcessorBase
{
    public string? Name { get; protected init; }
    public string? Socket { get; protected init; }
    public int MemoryFrequencies { get; protected init; }
    public int CoreFrequency { get; protected init; }
    public int CoresNumber { get; protected init; }
    public bool IntegratedVideoCore { get; protected init; }
    public int ThermalDesignPower { get; protected init; }
    public int PowerConsumption { get; protected init; }
}