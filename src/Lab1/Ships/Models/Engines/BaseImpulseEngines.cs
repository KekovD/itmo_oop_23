namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

public abstract class BaseImpulseEngines : BaseEngines
{
    protected int DesignSpeed { get; init; }
    protected int FuelUseAtStartup { get; init; }
    protected int FuelUsePerUnitTime { get; init; }
}