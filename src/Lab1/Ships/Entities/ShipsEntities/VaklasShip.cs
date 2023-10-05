using System;
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
        ShipWeight = ShipHull.PartWeight + ImpulseEngine.PartWeight + JumpEngine.PartWeight + ShipDeflector.PartWeight;
    }

    public override int ShipIJumpFuelCost(int distance)
    {
        return (int)Math.Pow(distance, 2) * (int)PriceOfFuel.PriceJumpFuel;
    }
}