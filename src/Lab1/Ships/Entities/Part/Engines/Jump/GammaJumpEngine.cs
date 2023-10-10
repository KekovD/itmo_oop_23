using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Jump;

public class GammaJumpEngine : BaseJumpEngines
{
    private const int GammaWeight = 300;
    private const int GammaDistance = 5000;
    private const int GammaFlowRate = 2;

    public GammaJumpEngine()
    {
        Rage = GammaDistance;
        JumpFuelConsumption = GammaFlowRate;
        PartWeight = GammaWeight;
    }

    public override int GetEngineFuelConsumption(int distance, int weightShip) =>
        (int)(JumpFuelConsumption * (int)Math.Pow(distance, 2) * (WeightRatio * weightShip));
}