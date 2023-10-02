using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.EngineSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

public class BaseJumpEngines : BaseEngines, IInterfacesForJumpEngine
{
    public int JumpFuelConsumption { get; protected init; }
    public int JumpRage { get; protected init; }
    public JumpEngineType JumpType { get; protected init; }
}