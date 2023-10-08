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

    public override int GetEngineFuelConsumption(int distance, int weightShip)
    {
        int speed = DesignSpeed - (int)(WeightRatio * weightShip);
        int time = (int)(speed / distance);

        return (time * FuelUsePerUnitTime) + FuelUseAtStartup;
    }
}