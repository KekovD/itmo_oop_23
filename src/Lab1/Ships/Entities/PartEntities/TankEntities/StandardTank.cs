using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement.ShipFuelManagement;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.TankModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;

public class StandardTank : BaseTank, IAmountOfStandardMoney
{
    public StandardTank(int fullStandardTank, int currentStandardFuelResidue, int moneyStandard)
    {
        FullTank = fullStandardTank;
        FuelResidue = currentStandardFuelResidue;
        StandardMoney = moneyStandard;
    }

    public int StandardMoney { get; }
}