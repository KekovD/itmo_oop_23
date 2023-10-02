using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.EnginesEntities.JumpEntities;

public class OmegaJumpEngine : BaseJumpEngines
{
    public OmegaJumpEngine()
    {
        TypeOfEngine = BaseEngineType.JumpEngine;
        JumpRage = (int)JumpEngineCharacteristics.OmegaDistance;
        JumpFuelConsumption = (int)JumpEngineCharacteristics.OmegaFlowRate;
    }
}