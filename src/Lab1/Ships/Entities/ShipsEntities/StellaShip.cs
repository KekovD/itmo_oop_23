using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.TankSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.ShipsEntities;

public class StellaShip : BaseShipWithJumpEngineAndDeflector
{
    public StellaShip(int currentStandardFuelResidue, int currentJumpFuelResidue, bool havePhotons)
    {
        ShipHull = new HullFirst();
        ShipStandardTank = new StandardTank(
            (int)CapacityTankStandard.CapacityStandardStella,
            currentStandardFuelResidue);
        ImpulseEngine = new CImpulseEngine();
        ShipJumpTank = new JumpTank(
            (int)CapacityTankJump.CapacityJumpStella,
            currentJumpFuelResidue);
        JumpEngine = new OmegaJumpEngine();
        ShipDeflector = new DeflectorFirst(havePhotons);
        ShipWeight = ShipHull.PartWeight + ShipStandardTank.PartWeight + ImpulseEngine.PartWeight +
                     ShipJumpTank.PartWeight + JumpEngine.PartWeight + ShipDeflector.PartWeight;
    }
}