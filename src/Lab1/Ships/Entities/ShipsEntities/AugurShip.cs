using Itmo.ObjectOrientedProgramming.Lab1.MyException;
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
    public AugurShip(bool havePhotons)
    {
        ShipHull = new HullThird();
        ShipStandardTank = new StandardTank((int)CapacityTankStandard.CapacityStandardAugur);
        ImpulseEngine = new EImpulseEngine();
        ShipJumpTank = new JumpTank((int)CapacityTankJump.CapacityJumpAugur);
        JumpEngine = new AlphaJumpEngine();
        ShipDeflector = new DeflectorThird(havePhotons);
        ShipWeight = ShipHull.PartWeight + ImpulseEngine.PartWeight + JumpEngine.PartWeight + ShipDeflector.PartWeight;
    }

    public override int ShipJumpFuelConsumption(int distance)
    {
        if (JumpEngine == null)
        {
            throw new PartOfShipNullException(nameof(JumpEngine));
        }

        return JumpEngine.JumpFuelConsumption * distance;
    }

    public override int ShipIJumpFuelCost(int distance)
    {
        if (JumpEngine == null)
        {
            throw new PartOfShipNullException(nameof(JumpEngine));
        }

        return ShipJumpFuelConsumption(distance) * (int)PriceOfFuel.PriceJumpFuel;
    }
}