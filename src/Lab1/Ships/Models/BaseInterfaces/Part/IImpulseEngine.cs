namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Part;

public interface IImpulseEngine
{
    int DesignSpeed { get; }
    int FuelUseAtStartup { get; }
    int FuelUsePerUnitTime { get; }
}