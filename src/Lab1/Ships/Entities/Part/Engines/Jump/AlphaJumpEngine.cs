using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Jump;

public class AlphaJumpEngine : BaseJumpEngines
{
    private const int AlphaWeight = 200;
    private const int AlphaDistance = 1000;
    private const int AlphaFlowRate = 10;

    public AlphaJumpEngine()
    {
        Rage = AlphaDistance;
        JumpFuelConsumption = AlphaFlowRate;
        PartWeight = AlphaWeight;
    }

    public override int GetEngineFuelConsumption(int distance, int weightShip) =>
        (int)((JumpFuelConsumption * distance) * (WeightRatio * weightShip));
}