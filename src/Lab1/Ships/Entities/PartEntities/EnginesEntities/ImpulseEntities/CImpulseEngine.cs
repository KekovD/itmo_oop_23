using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.EngineSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;

public class CImpulseEngine : BaseImpulseEngines
{
    public CImpulseEngine()
    {
        TypeOfEngine = BaseEngineType.StandardEngine;
        ImpulseType = ImpulseEngineType.CLassType;
        DesignSpeed = (int)StandardEngineSpeed.CSpeed;
        FuelUseAtStartup = (int)StandardEngineFuelFlow.CEngineConstantFuelFlow;
        FuelUsePerUnitTime = (int)StandardEngineFuelFlow.CEngineConstantFuelFlow;
        PartWeight = (int)WeightOfEngine.CLassWeight;
    }

    public override int GetImpulseEngineSpeed(int distance)
    {
        return DesignSpeed;
    }
}