using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.TankSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.ShipsEntities;

public class WalkingShuttleShip : BaseShip
{
    public WalkingShuttleShip(int currentStandardFuelResidue)
    {
        ShipHull = new HullFirst();
        ShipStandardTank = new StandardTank(
            (int)CapacityTankStandard.CapacityStandardWalkingShuttle,
            currentStandardFuelResidue);
        ImpulseEngine = new CImpulseEngine();
        ShipWeight = ShipHull.PartWeight + ImpulseEngine.PartWeight;
    }
}