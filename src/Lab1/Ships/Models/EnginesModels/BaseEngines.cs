using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.PartInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

public abstract class BaseEngines : IPartWeight
{
    protected const int CLassWeight = 100;
    protected const int EClassWeight = 150;
    protected const int AlphaWeight = 200;
    protected const int OmegaWeight = 250;
    protected const int GammaWeight = 300;
    public int PartWeight { get; protected init; }
}