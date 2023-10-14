namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

public abstract class EnginesBaseJump : EnginesBase
{
    public int Rage { get; protected init; }
    protected int JumpFuelConsumption { get; init; }
}