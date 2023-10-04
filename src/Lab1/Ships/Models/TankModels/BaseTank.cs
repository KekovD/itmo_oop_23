using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement.ShipFuelManagement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.TankModels;

public abstract class BaseTank : IShipTank, IPartWeight, IFuelWeightCalculation
{
    private const double FuelWeightRatio = 0.1;
    public int FullTank { get; protected init; }
    public int FuelResidue { get; protected set; }
    public int PartWeight { get; private set; }

    public void FuelWeight()
    {
        PartWeight = (int)(FuelResidue * FuelWeightRatio);
    }
}