using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.TankSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.ShipsEntities;

public class MeredianShip : BaseShipWithDeflector
{
    public MeredianShip(bool havePhotons)
    {
        ShipHull = new HullSecond();
        ShipStandardTank = new StandardTank((int)CapacityTankStandard.CapacityStandardMeredian);
        ImpulseEngine = new EImpulseEngine();
        ShipDeflector = new DeflectorSecond(havePhotons);
        ShipAntiNitrinoEmitter = true;
        ShipWeight = ShipHull.PartWeight + ImpulseEngine.PartWeight + ShipDeflector.PartWeight;
    }
}