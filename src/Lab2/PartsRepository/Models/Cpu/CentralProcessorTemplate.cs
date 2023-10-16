namespace Itmo.ObjectOrientedProgramming.Lab2.PartsRepository.Models.Cpu;

public abstract class CentralProcessorTemplate
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