namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.DeflectorsInterfaces;

public interface IDeflectorInterface
{
    int HealthOfDeflector { get; }
    bool DeflectAntimatterFlares { get; }
    int PhotonsHealth { get; }
    void SetHealthOfPhotonsDeflector(int newValue);
    void SetHealthOfDeflector(int newValue);
}