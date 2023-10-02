using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;

public class GammaJumpEngine : BaseJumpEngines
{
    public GammaJumpEngine()
    {
        TypeOfEngine = BaseEngineType.JumpEngine;
        JumpType = JumpEngineType.GammaType;
        JumpRage = (int)JumpEngineSpeedAndFuelFlow.GammaDistance;
        JumpFuelConsumption = (int)JumpEngineSpeedAndFuelFlow.GammaFlowRate;
        PartWeight = (int)WeightOfEngine.GammaWeight;
    }
}