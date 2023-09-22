using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

public abstract class EngineTypeIdentification : ITypeOfSpeed
{
    public int Gradation { get; protected init; }
    public BaseEngineType TypeOfEngine { get; protected init; }
    protected static BaseEngineType EngineIdentification(int grade)
    {
        return grade switch
        {
            0 or 1 => BaseEngineType.StandardEngine,
            2 or 3 or 4 => BaseEngineType.JumpEngine,
            _ => throw new System.ArgumentException("Invalid grade value", nameof(grade)),
        };
    }
}