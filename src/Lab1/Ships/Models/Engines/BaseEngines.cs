using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

public abstract class BaseEngines : IGradationPart, ICanBeLaunched, IFuelConsumption
{
    public int Gradation { get; protected set; }
    public bool Running { get; protected set; }
    public bool Serviceability { get; protected set; }
    public int FuelUseAtStartup { get; protected set; }
    public int FuelCUsePerUnitTime { get; protected set; }
}