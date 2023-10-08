using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Impulse;

public class EImpulseEngine : BaseImpulseEngines
{
    public EImpulseEngine()
    {
        DesignSpeed = ESpeed;
        FuelUseAtStartup = EEngineFuelFlow;
        FuelUsePerUnitTime = EEngineFuelFlow;
        PartWeight = EClassWeight;
    }

    public override int GetEngineFuelConsumption(int distance, int weightShip)
    {
        int speed = DesignSpeed + (int)Math.Exp(distance) - (int)(WeightRatio * weightShip);
        int time = (int)(speed / distance);

        return (time * FuelUsePerUnitTime) + FuelUseAtStartup;
    }
}