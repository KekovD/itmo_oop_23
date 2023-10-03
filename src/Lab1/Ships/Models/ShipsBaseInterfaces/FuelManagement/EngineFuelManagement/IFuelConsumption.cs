namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement.EngineFuelManagement;

public interface IFuelConsumption : IFuelConsumptionPerUnitTime
{
    int FuelUseAtStartup { get; }
}