using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;

public class CImpulseEngine : BaseImpulseEngines
{
    public CImpulseEngine()
    {
        DesignSpeed = CSpeed;
        FuelUseAtStartup = CEngineFuelFlow;
        FuelUsePerUnitTime = CEngineFuelFlow;
        PartWeight = CLassWeight;
    }

    public override int GetImpulseEngineSpeed(int distance)
    {
        return DesignSpeed;
    }
}