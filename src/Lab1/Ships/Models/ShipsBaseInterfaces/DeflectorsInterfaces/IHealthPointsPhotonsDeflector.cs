namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.DeflectorsInterfaces;

public interface IHealthPointsPhotonsDeflector : IInitHealthPointsPhotonsDeflector
{
    int PhotonsHealth { get; }
}