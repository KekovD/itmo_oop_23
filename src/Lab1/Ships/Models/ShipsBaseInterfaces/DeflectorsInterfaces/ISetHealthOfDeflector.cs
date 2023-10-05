namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.DeflectorsInterfaces;

public interface ISetHealthOfDeflector : ISetHealthOfPhotonsDeflector
{
    void SetHealthOfDeflector(int newValue);
}