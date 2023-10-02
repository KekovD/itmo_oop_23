using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.EngineSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;

public class EImpulseEngine : BaseImpulseEngines, IExponentialAcceleration
{
    public EImpulseEngine()
    {
        TypeOfEngine = BaseEngineType.StandardEngine;
        ImpulseType = ImpulseEngineType.EClassType;
        DesignSpeed = (int)StandardEngineSpeedAndFuelFlow.ESpeed;
        FuelUseAtStartup = (int)StandardEngineSpeedAndFuelFlow.EEngineConstantFuelFlow;
        FuelUsePerUnitTime = (int)StandardEngineSpeedAndFuelFlow.EEngineConstantFuelFlow;
        PartWeight = (int)WeightOfEngine.EClassWeight;
    }

    public int ExponentialAcceleration(int speed, int distance)
    {
        return speed + (int)Math.Exp(distance);
    }
}