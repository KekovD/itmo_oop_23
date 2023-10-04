using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.TankModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;

public class JumpTank : BaseTank
{
    public JumpTank()
    {
    }

    public JumpTank(int fullJumpTank, int currentJumpFuelResidue)
    {
        FullTank = fullJumpTank;
        FuelResidue = currentJumpFuelResidue;
        FuelWeight();
    }
}