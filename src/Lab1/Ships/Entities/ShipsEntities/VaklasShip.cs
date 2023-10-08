using System;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.TankSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.ShipsEntities;

public class VaklasShip : BaseShipWithJumpEngineAndDeflector
{
    public VaklasShip(bool havePhotons)
    {
        Hull = new HullSecond();
        ImpulseEngine = new EImpulseEngine();
        JumpEngine = new GammaJumpEngine();
        Deflector = new DeflectorFirst(havePhotons);
        Weight = Hull.PartWeight + ImpulseEngine.PartWeight + JumpEngine.PartWeight + Deflector.PartWeight;
    }

    public override int JumpFuelConsumption(int distance)
    {
        if (JumpEngine == null)
        {
            throw new PartOfShipNullException(nameof(JumpEngine));
        }

        return JumpEngine.JumpFuelConsumption * (int)Math.Pow(distance, 2);
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