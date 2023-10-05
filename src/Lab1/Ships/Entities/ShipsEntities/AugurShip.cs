using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.TankSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.ShipsEntities;

public class AugurShip : BaseShipWithJumpEngineAndDeflector
{
    public AugurShip(int currentStandardFuelResidue, int currentJumpFuelResidue, bool havePhotons)
    {
        ShipHull = new HullThird();
        ShipStandardTank = new StandardTank(
            (int)CapacityTankStandard.CapacityStandardAugur,
            currentStandardFuelResidue);
        ImpulseEngine = new EImpulseEngine();
        ShipJumpTank = new JumpTank(
            (int)CapacityTankJump.CapacityJumpAugur,
            currentJumpFuelResidue);
        JumpEngine = new AlphaJumpEngine();
        ShipDeflector = new DeflectorThird(havePhotons);
        ShipWeight = ShipHull.PartWeight + ImpulseEngine.PartWeight + JumpEngine.PartWeight + ShipDeflector.PartWeight +
                     ShipStandardTank.PartWeight + ShipJumpTank.PartWeight;
    }
}