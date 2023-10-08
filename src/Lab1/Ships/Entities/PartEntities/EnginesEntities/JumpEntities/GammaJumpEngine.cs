using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;

public class GammaJumpEngine : BaseJumpEngines
{
    public GammaJumpEngine()
    {
        JumpRage = GammaDistance;
        JumpFuelConsumption = GammaFlowRate;
        PartWeight = GammaWeight;
    }
}