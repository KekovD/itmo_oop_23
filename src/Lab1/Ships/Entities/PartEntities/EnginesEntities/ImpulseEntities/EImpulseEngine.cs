using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.EngineSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;

public class EImpulseEngine : BaseImpulseEngines
{
    public EImpulseEngine()
    {
        DesignSpeed = (int)StandardEngineSpeed.ESpeed;
        FuelUseAtStartup = (int)StandardEngineFuelFlow.EEngineConstantFuelFlow;
        FuelUsePerUnitTime = (int)StandardEngineFuelFlow.EEngineConstantFuelFlow;
        PartWeight = (int)WeightOfEngine.EClassWeight;
    }

    public override int GetImpulseEngineSpeed(int distance)
    {
        return DesignSpeed + (int)Math.Exp(distance);
    }
}