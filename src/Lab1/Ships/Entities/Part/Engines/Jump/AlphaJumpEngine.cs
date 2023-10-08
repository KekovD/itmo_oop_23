using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Jump;

public class AlphaJumpEngine : BaseJumpEngines
{
    public AlphaJumpEngine()
    {
        Rage = AlphaDistance;
        JumpFuelConsumption = AlphaFlowRate;
        PartWeight = AlphaWeight;
    }

    public override int GetEngineFuelConsumption(int distance, int weightShip) =>
        (int)((JumpFuelConsumption * distance) * (WeightRatio * weightShip));
}