using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.EnginesEntities;

public class CImpulseEngine : BaseEngines
{
    public CImpulseEngine(int grade)
        : base(grade)
    {
        TypeOfEngine = BaseEngineType.StandardEngine;
        FuelUseAtStartup = (int)StandardEngineCharacteristics.CEngineConstantFuelFlow;
        FuelUsePerUnitTime = (int)StandardEngineCharacteristics.CEngineConstantFuelFlow;
    }
}