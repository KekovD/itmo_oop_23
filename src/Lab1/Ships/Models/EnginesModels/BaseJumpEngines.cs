using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

public class BaseJumpEngines : BaseEngines, IJumpFuelConsumption, IJumpRange
{
    public int JumpFuelConsumption { get; protected init; }
    public int JumpRage { get; protected init; }
}