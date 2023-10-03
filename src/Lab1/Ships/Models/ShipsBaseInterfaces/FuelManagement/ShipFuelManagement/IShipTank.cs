namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement.ShipFuelManagement;

public interface IShipTank : IFuelResidue
{
    int FullTank { get; }
}