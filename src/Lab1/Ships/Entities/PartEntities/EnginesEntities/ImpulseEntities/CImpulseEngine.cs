using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;

public class CImpulseEngine : BaseImpulseEngines
{
    public CImpulseEngine()
    {
        TypeOfEngine = BaseEngineType.StandardEngine;
        ImpulseType = ImpulseEngineType.CLassType;
        DesignSpeed = (int)StandardEngineSpeedAndFuelFlow.CSpeed;
        FuelUseAtStartup = (int)StandardEngineSpeedAndFuelFlow.CEngineConstantFuelFlow;
        FuelUsePerUnitTime = (int)StandardEngineSpeedAndFuelFlow.CEngineConstantFuelFlow;
        PartWeight = (int)WeightOfEngine.CLassWeight;
    }
}