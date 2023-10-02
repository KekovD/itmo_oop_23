using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.EnginesEntities;

public class EImpulseEngine : BaseImpulseEngines, IExponentialAcceleration
{
    public EImpulseEngine()
    {
        TypeOfEngine = BaseEngineType.StandardEngine;
        DesignSpeed = (int)StandardEngineCharacteristics.ESpeed;
        FuelUseAtStartup = (int)StandardEngineCharacteristics.EEngineConstantFuelFlow;
        FuelUsePerUnitTime = (int)StandardEngineCharacteristics.EEngineConstantFuelFlow;
    }

    public int ExponentialAcceleration(int speed, int distance)
    {
        return speed + (int)Math.Exp(distance);
    }
}