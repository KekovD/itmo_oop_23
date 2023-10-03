using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.EngineSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;

public class AlphaJumpEngine : BaseJumpEngines
{
    public AlphaJumpEngine()
    {
        TypeOfEngine = BaseEngineType.JumpEngine;
        JumpType = JumpEngineType.AlphaType;
        JumpRage = (int)JumpEngineDistance.AlphaDistance;
        JumpFuelConsumption = (int)JumpEngineFuelFlow.AlphaFlowRate;
        PartWeight = (int)WeightOfEngine.AlphaWeight;
    }
}