using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

public abstract class BaseEngines : EngineTypeIdentification, ICanBeLaunched, IFuelConsumption
{
    protected BaseEngines(int grade)
    {
        Gradation = grade;
        TypeOfEngine = EngineIdentification(grade);
        Running = false;
        Serviceability = true;
    }

    public bool Running { get; }
    public bool Serviceability { get; }
    public int FuelUseAtStartup { get; protected set; }
    public int FuelUsePerUnitTime { get; protected set; }
}