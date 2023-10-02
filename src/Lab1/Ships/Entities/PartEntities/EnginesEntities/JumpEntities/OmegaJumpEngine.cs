using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;

public class OmegaJumpEngine : BaseJumpEngines
{
    public OmegaJumpEngine()
    {
        TypeOfEngine = BaseEngineType.JumpEngine;
        JumpType = JumpEngineType.OmegaType;
        JumpRage = (int)JumpEngineSpeedAndFuelFlow.OmegaDistance;
        JumpFuelConsumption = (int)JumpEngineSpeedAndFuelFlow.OmegaFlowRate;
        PartWeight = (int)WeightOfEngine.OmegaWeight;
    }
}