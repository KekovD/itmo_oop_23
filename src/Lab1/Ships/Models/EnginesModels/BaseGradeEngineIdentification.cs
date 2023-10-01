using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

public abstract class BaseGradeEngineIdentification : IGradeEngineIdentification
{
    public BaseEngineType EngineIdentification(int grade) ////TODO: refactor exception
    {
        return grade switch
        {
            0 or 1 => BaseEngineType.StandardEngine,
            2 or 3 or 4 => BaseEngineType.JumpEngine,
            _ => throw new System.ArgumentException("Invalid grade engine value", nameof(grade)),
        };
    }
}