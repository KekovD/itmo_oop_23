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
        DesignSpeed = (int)StandardEngineSpeed.ESpeed;
        FuelUseAtStartup = (int)StandardEngineFuelFlow.EEngineConstantFuelFlow;
        FuelUsePerUnitTime = (int)StandardEngineFuelFlow.EEngineConstantFuelFlow;
        PartWeight = (int)WeightOfEngine.EClassWeight;
    }

    public int ETransitTime(int distance)
    {
        return DesignSpeed + (int)Math.Exp(distance);
    }
}