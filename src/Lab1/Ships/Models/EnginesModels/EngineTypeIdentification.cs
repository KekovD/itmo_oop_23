using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

public abstract class EngineTypeIdentification : BaseGradeEngineIdentification, ITypeOfSpeed
{
    public int Gradation { get; protected init; }
    public BaseEngineType TypeOfEngine { get; protected init; }
}