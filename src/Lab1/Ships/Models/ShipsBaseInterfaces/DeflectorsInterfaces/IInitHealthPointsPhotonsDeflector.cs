namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.DeflectorsInterfaces;

public interface IInitHealthPointsPhotonsDeflector : ICanDeflectAntimatterFlares
{
    int InitPhotonsDeflectorHealthPoints(bool photons);
}