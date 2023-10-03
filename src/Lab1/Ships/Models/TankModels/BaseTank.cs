using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement.ShipFuelManagement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.TankModels;

public class BaseTank : IShipTank
{
    public int FullTank { get; protected init; }
    public int FuelResidue { get; protected set; }
}