using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;

public class AlphaJumpEngine : BaseJumpEngines
{
    public AlphaJumpEngine()
    {
        JumpRage = AlphaDistance;
        JumpFuelConsumption = AlphaFlowRate;
        PartWeight = AlphaWeight;
    }

    public override int GetEngineFuelConsumption(int distance, int weightShip) =>
        (int)((JumpFuelConsumption * distance) * (WeightRatio * weightShip));
}