using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.TankSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.ShipsEntities;

public class WalkingShuttleShip : BaseShip
{
    private BaseImpulseEngines _impulseEngine;
    private BaseHull _hull;
    private StandardTank _standardTank;

    public WalkingShuttleShip(int currentStandardFuelResidue, int moneyStandard)
    {
        _hull = new HullFirst();
        _standardTank = new StandardTank(
            (int)CapacityTankStandard.CapacityStandardWalkingShuttle,
            currentStandardFuelResidue,
            moneyStandard);
        _impulseEngine = new CImpulseEngine();
        HaveJumpEngine = false;
        HaveDeflector = false;
    }
}