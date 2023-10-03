using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.FuelManagement.ShipFuelManagement;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.TankModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;

public class JumpTank : BaseTank, IAmountOfJumpMoney
{
    public JumpTank(int fullJumpTank, int currentJumpFuelResidue, int moneyJump)
    {
        FullTank = fullJumpTank;
        FuelResidue = currentJumpFuelResidue;
        JumpMoney = moneyJump;
    }

    public int JumpMoney { get; }
}