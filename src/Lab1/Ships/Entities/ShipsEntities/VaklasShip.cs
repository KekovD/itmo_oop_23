using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.TankSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.ShipsEntities;

public class VaklasShip : BaseShipWithJumpEngineAndDeflector
{
    public VaklasShip(int currentStandardFuelResidue, int currentJumpFuelResidue, bool havePhotons)
    {
        ShipHull = new HullSecond();
        ShipStandardTank = new StandardTank(
            (int)CapacityTankStandard.CapacityStandardVaklas,
            currentStandardFuelResidue);
        ImpulseEngine = new EImpulseEngine();
        ShipJumpTank = new JumpTank(
            (int)CapacityTankJump.CapacityJumpVaklas,
            currentJumpFuelResidue);
        JumpEngine = new GammaJumpEngine();
        ShipDeflector = new DeflectorFirst(havePhotons);
        ShipWeight = ShipHull.PartWeight + ShipStandardTank.PartWeight + ImpulseEngine.PartWeight +
                     ShipJumpTank.PartWeight + JumpEngine.PartWeight + ShipDeflector.PartWeight;
    }
}