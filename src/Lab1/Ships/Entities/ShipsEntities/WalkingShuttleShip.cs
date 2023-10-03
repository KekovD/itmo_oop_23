using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.TankSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.ShipsEntities;

public class WalkingShuttleShip : BaseShip
{
    public WalkingShuttleShip(int currentStandardFuelResidue, int moneyStandard)
    {
        ShipHull = new HullFirst();
        ShipStandardTank = new StandardTank(
            (int)CapacityTankStandard.CapacityStandardWalkingShuttle,
            currentStandardFuelResidue,
            moneyStandard);
        ImpulseEngine = new CImpulseEngine();
        HaveJumpEngine = false;
        HaveDeflector = false;
    }
}