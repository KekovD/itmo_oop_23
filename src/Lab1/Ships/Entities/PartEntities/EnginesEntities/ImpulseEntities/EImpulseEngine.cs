using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;

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