namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.PartInterfaces;

public interface IGetEngineFuelConsumption
{
    int GetEngineFuelConsumption(int distance, int weightShip);
}