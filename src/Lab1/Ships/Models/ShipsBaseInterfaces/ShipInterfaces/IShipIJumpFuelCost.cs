namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

public interface IShipIJumpFuelCost : IShipJumpFuelConsumption
{
    int ShipIJumpFuelCost(int distance);
}