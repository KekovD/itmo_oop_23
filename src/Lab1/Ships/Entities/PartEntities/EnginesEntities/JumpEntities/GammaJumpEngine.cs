using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;

public class GammaJumpEngine : BaseJumpEngines
{
    public GammaJumpEngine()
    {
        Rage = GammaDistance;
        JumpFuelConsumption = GammaFlowRate;
        PartWeight = GammaWeight;
    }

    public override int GetEngineFuelConsumption(int distance, int weightShip) =>
        (int)(JumpFuelConsumption * (int)Math.Pow(distance, 2) * (WeightRatio * weightShip));
}