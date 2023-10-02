using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.EnginesEntities;

public class AlphaJumpEngine : BaseJumpEngines
{
    public AlphaJumpEngine()
    {
        TypeOfEngine = BaseEngineType.JumpEngine;
        JumpRage = (int)JumpEngineCharacteristics.AlphaDistance;
        JumpFuelConsumption = (int)JumpEngineCharacteristics.AlphaFlowRate;
    }
}