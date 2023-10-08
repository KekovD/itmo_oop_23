using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.DeflectorEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.ShipsEntities;

public class MeredianShip : BaseShipWithDeflector
{
    public MeredianShip(bool havePhotons)
    {
        Hull = new HullSecond();
        ImpulseEngine = new EImpulseEngine();
        Deflector = new DeflectorSecond(havePhotons);
        AntiNitrinoEmitter = true;
        Weight = Hull.PartWeight + ImpulseEngine.PartWeight + Deflector.PartWeight;
    }
}