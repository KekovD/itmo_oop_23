using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

public class BaseImpulseEngines : BaseEngines, IDesignSpeedOfEngine, ICurrentEngineSpeed, IFuelConsumption
{
    public int DesignSpeed { get; protected init; }
    public int CurrentEngineSpeed { get; protected set; }
    public int FuelUseAtStartup { get; protected init; }
    public int FuelUsePerUnitTime { get; protected init; }
}