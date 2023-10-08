using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;

public class OmegaJumpEngine : BaseJumpEngines
{
    public OmegaJumpEngine()
    {
        Rage = OmegaDistance;
        JumpFuelConsumption = OmegaFlowRate;
        PartWeight = OmegaWeight;
    }

    public override int GetEngineFuelConsumption(int distance, int weightShip) =>
        (int)(JumpFuelConsumption * distance * Math.Log2(distance) * (WeightRatio * weightShip));
}