using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.EnginesEntities.JumpEntities;

public class AlphaJumpEngine : BaseJumpEngines
{
    public AlphaJumpEngine()
    {
        TypeOfEngine = BaseEngineType.JumpEngine;
        JumpType = JumpEngineType.AlphaType;
        JumpRage = (int)JumpEngineSpeedAndFuelFlow.AlphaDistance;
        JumpFuelConsumption = (int)JumpEngineSpeedAndFuelFlow.AlphaFlowRate;
        PartWeight = (int)WeightOfEngine.AlphaWeight;
    }
}