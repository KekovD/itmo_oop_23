namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;

public interface IImpulseEngineInterfaces
{
    int DesignSpeed { get; }
    int FuelUseAtStartup { get; }
    int FuelUsePerUnitTime { get; }
    int GetImpulseEngineSpeed(int distance);
}