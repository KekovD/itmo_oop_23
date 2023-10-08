namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Part;

public interface IGetEngineFuel
{
    int GetEngineFuelConsumption(int distance, int weightShip);
}