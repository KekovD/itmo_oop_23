using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Jump;

public class OmegaJump : EnginesBaseJump
{
    private const int OmegaWeight = 250;
    private const int OmegaDistance = 2500;
    private const int OmegaFlowRate = 5;

    public OmegaJump()
    {
        Rage = OmegaDistance;
        JumpFuelConsumption = OmegaFlowRate;
        PartWeight = OmegaWeight;
    }

    public override int GetEngineFuelConsumption(int distance, int weightShip) =>
        (int)(JumpFuelConsumption * distance * Math.Log2(distance) * (WeightRatio * weightShip));
}