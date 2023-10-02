using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.EnginesEntities.JumpEntities;

public class GammaJumpEngine : BaseJumpEngines
{
    public GammaJumpEngine()
    {
        TypeOfEngine = BaseEngineType.JumpEngine;
        JumpRage = (int)JumpEngineCharacteristics.GammaDistance;
        JumpFuelConsumption = (int)JumpEngineCharacteristics.GammaFlowRate;
    }
}