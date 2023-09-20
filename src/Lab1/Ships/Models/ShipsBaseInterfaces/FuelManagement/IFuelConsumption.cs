namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement;

public interface IFuelConsumption : IFuelConsumptionPerUnitTime
{
    int FuelUseAtStartup { get; set; }
}