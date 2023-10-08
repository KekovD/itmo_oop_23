using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Ships;

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