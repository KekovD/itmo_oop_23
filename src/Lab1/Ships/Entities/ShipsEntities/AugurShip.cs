using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.JumpEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.TankSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.ShipsEntities;

public class AugurShip : BaseShipWithJumpEngineAndDeflector
{
    public AugurShip(bool havePhotons)
    {
        Hull = new HullThird();
        ImpulseEngine = new EImpulseEngine();
        JumpEngine = new AlphaJumpEngine();
        Deflector = new DeflectorThird(havePhotons);
        Weight = Hull.PartWeight + ImpulseEngine.PartWeight + JumpEngine.PartWeight + Deflector.PartWeight;
    }

    public override int JumpFuelConsumption(int distance)
    {
        if (JumpEngine == null)
        {
            throw new PartOfShipNullException(nameof(JumpEngine));
        }

        return JumpEngine.JumpFuelConsumption * distance;
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