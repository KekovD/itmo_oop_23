namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Part;

public interface IDeflector
{
    int HealthOfDeflector { get; }
    bool DeflectAntimatterFlares { get; }
    int PhotonsHealth { get; }
    void DamagingPhotonsDeflector(int damage);
    void DamagingDeflector(int damage);
}