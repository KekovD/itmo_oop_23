using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.EngineSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;

public class OmegaJumpEngine : BaseJumpEngines
{
    public OmegaJumpEngine()
    {
        JumpRage = (int)JumpEngineDistance.OmegaDistance;
        JumpFuelConsumption = (int)JumpEngineFuelFlow.OmegaFlowRate;
        PartWeight = (int)WeightOfEngine.OmegaWeight;
    }
}