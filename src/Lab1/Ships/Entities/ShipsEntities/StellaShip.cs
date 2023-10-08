using System;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.TankSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.ShipsEntities;

public class StellaShip : BaseShipWithJumpEngineAndDeflector
{
    public StellaShip(bool havePhotons)
    {
        Hull = new HullFirst();
        ImpulseEngine = new CImpulseEngine();
        JumpEngine = new OmegaJumpEngine();
        Deflector = new DeflectorFirst(havePhotons);
        Weight = Hull.PartWeight + ImpulseEngine.PartWeight + JumpEngine.PartWeight + Deflector.PartWeight;
    }

    public override int JumpFuelConsumption(int distance)
    {
        if (JumpEngine == null)
        {
            throw new PartOfShipNullException(nameof(JumpEngine));
        }

        return (int)(JumpEngine.JumpFuelConsumption * distance * Math.Log2(distance));
    }

    public override int JumpFuelCost(int distance)
    {
        if (JumpEngine == null)
        {
            throw new PartOfShipNullException(nameof(JumpEngine));
        }

        return JumpFuelConsumption(distance) * (int)PriceOfFuel.PriceJumpFuel;
    }
}