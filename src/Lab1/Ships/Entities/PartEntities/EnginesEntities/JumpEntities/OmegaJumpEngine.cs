using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;

public class OmegaJumpEngine : BaseJumpEngines
{
    public OmegaJumpEngine()
    {
        JumpRage = OmegaDistance;
        JumpFuelConsumption = OmegaFlowRate;
        PartWeight = OmegaWeight;
    }
}