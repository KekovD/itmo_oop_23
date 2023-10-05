namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

public interface IGetImpulseFuelCost : IShipImpulseFuelConsumption
{
    int ShipImpulseFuelCost(int distance);
}