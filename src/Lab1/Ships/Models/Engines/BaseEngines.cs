using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Part;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

public abstract class BaseEngines : IGetEngineFuel, IPartWeight
{
    protected const double WeightRatio = 0.05;
    protected const int CLassWeight = 100;
    protected const int EClassWeight = 150;
    protected const int AlphaWeight = 200;
    protected const int OmegaWeight = 250;
    protected const int GammaWeight = 300;
    public int PartWeight { get; protected init; }
    public abstract int GetEngineFuelConsumption(int distance, int weightShip);
}