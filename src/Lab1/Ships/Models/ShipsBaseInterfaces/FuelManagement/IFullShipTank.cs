namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement;

public interface IFullShipTank : IFuelQuantity
{
    int FullTank { get; set; }
}