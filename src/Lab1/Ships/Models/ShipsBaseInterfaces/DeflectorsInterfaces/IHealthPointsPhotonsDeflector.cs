namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.DeflectorsInterfaces;

public interface IHealthPointsPhotonsDeflector : ICanDeflectAntimatterFlares
{
    int PhotonsHealth { get; }
}