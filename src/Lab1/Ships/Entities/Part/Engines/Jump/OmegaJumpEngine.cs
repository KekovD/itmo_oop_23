using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Jump;

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