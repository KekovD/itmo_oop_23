using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.TankModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;

public class StandardTank : BaseTank
{
    public StandardTank()
    {
    }

    public StandardTank(int fullStandardTank, int currentStandardFuelResidue)
    {
        FullTank = fullStandardTank;
        FuelResidue = currentStandardFuelResidue;
        FuelWeight();
    }
}