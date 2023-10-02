using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;

public abstract class BaseEngines : EngineTypeIdentification, ICanBeLaunched, IFuelConsumption, ICurrentEngineSpeed, IDesignSpeedOfEngine
{
    protected BaseEngines(int grade)
    {
        Gradation = grade;
        Running = false;
        CurrentEngineSpeed = 0;
        Serviceability = true;
    }

    public int CurrentEngineSpeed { get; protected set; }
    public int DesignSpeed { get; protected init; }
    public bool Running { get; }
    public bool Serviceability { get; }
    public int FuelUseAtStartup { get; protected init; }
    public int FuelUsePerUnitTime { get; protected init; }
}