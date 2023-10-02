using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.EnginesEntities.ImpulseEntities;

public class CImpulseEngine : BaseImpulseEngines
{
    public CImpulseEngine()
    {
        TypeOfEngine = BaseEngineType.StandardEngine;
        ImpulseType = ImpulseEngineType.CLassType;
        DesignSpeed = (int)StandardEngineCharacteristics.CSpeed;
        FuelUseAtStartup = (int)StandardEngineCharacteristics.CEngineConstantFuelFlow;
        FuelUsePerUnitTime = (int)StandardEngineCharacteristics.CEngineConstantFuelFlow;
    }
}