using System;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
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
    public StellaShip(bool havePhotons)
    {
        ShipHull = new HullFirst();
        ShipStandardTank = new StandardTank((int)CapacityTankStandard.CapacityStandardStella);
        ImpulseEngine = new CImpulseEngine();
        ShipJumpTank = new JumpTank((int)CapacityTankJump.CapacityJumpStella);
        JumpEngine = new OmegaJumpEngine();
        ShipDeflector = new DeflectorFirst(havePhotons);
        ShipWeight = ShipHull.PartWeight + ImpulseEngine.PartWeight + JumpEngine.PartWeight + ShipDeflector.PartWeight;
    }

    public override int ShipJumpFuelConsumption(int distance)
    {
        if (JumpEngine == null)
        {
            throw new PartOfShipNullException(nameof(JumpEngine));
        }

        return (int)(JumpEngine.JumpFuelConsumption * distance * Math.Log2(distance));
    }

    public override int ShipIJumpFuelCost(int distance)
    {
        if (JumpEngine == null)
        {
            throw new PartOfShipNullException(nameof(JumpEngine));
        }

        return (int)(JumpEngine.JumpFuelConsumption * distance * Math.Log2(distance)) * (int)PriceOfFuel.PriceJumpFuel;
    }
}