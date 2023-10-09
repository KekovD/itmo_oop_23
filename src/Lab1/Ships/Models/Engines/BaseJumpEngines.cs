namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

public abstract class BaseJumpEngines : BaseEngines
{
    protected const int AlphaDistance = 1000;
    protected const int OmegaDistance = 2500;
    protected const int GammaDistance = 5000;
    protected const int AlphaFlowRate = 10;
    protected const int OmegaFlowRate = 5;
    protected const int GammaFlowRate = 2;
    public int Rage { get; protected init; }
    protected int JumpFuelConsumption { get; init; }
}