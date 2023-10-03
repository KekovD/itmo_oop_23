using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.EngineSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;

public class GammaJumpEngine : BaseJumpEngines
{
    public GammaJumpEngine()
    {
        TypeOfEngine = BaseEngineType.JumpEngine;
        JumpType = JumpEngineType.GammaType;
        JumpRage = (int)JumpEngineDistance.GammaDistance;
        JumpFuelConsumption = (int)JumpEngineFuelFlow.GammaFlowRate;
        PartWeight = (int)WeightOfEngine.GammaWeight;
    }
}