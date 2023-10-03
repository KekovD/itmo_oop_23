using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement.EngineFuelManagement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;

public interface IInterfacesForImpulseEngine : IDesignSpeedOfEngine, ICurrentEngineSpeed, IFuelConsumption, IImpulseType
{
}