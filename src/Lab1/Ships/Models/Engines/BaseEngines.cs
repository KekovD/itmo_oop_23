namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

public abstract class BaseEngines
{
    protected const double WeightRatio = 0.1;
    public int PartWeight { get; protected init; }
    public abstract int GetEngineFuelConsumption(int distance, int weightShip);
}