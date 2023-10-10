using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Impulse;

public class CImpulseEngine : BaseImpulseEngines
{
    private const int CLassWeight = 100;
    private const int CSpeed = 20;
    private const int CEngineFuelFlow = 10;

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