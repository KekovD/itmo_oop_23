using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.ShipsEntities;

public class MeredianShip : BaseShipWithDeflector
{
    public MeredianShip(bool havePhotons)
    {
        ShipHull = new HullSecond();
        ImpulseEngine = new EImpulseEngine();
        ShipDeflector = new DeflectorSecond(havePhotons);
        ShipAntiNitrinoEmitter = true;
        ShipWeight = ShipHull.PartWeight + ImpulseEngine.PartWeight + ShipDeflector.PartWeight;
    }
}