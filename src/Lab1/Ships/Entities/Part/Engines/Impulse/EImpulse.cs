using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Impulse;

public class EImpulse : EnginesImpulseBase, INitrinoParticleNebulae
{
    private const int EClassWeight = 150;
    private const int ESpeed = 30;
    private const int EEngineFuelFlow = 25;

    public EImpulse()
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