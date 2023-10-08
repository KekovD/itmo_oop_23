namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.PartInterfaces;

public interface IShipTank
{
    int FullTank { get; }
    int FuelResidue { get; }
    void SetFuelResidue(int newValue);
}