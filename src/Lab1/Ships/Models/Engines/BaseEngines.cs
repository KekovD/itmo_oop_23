using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

public abstract class BaseEngines : ITypeOfSpeed, ICanBeLaunched, IFuelConsumption
{
    protected BaseEngines(int grade)
    {
        Gradation = grade;
        TypeOfEngine = EngineTypeIdentification(grade);
        Running = false;
        Serviceability = true;
    }

    public int Gradation { get; }
    public BaseEngineType TypeOfEngine { get; }
    public bool Running { get; protected set; }
    public bool Serviceability { get; protected set; }
    public int FuelUseAtStartup { get; protected set; }
    public int FuelUsePerUnitTime { get; protected set; }
    public BaseEngineType EngineTypeIdentification(int grade)
    {
        return grade switch
        {
            0 or 1 => BaseEngineType.StandardEngine,
            2 or 3 or 4 => BaseEngineType.JumpEngine,
            _ => throw new System.ArgumentException("Invalid grade value", nameof(grade)),
        };
    }
}