using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Jump;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Ships;

public class VaklasShip : BaseShipWithJumpEngineAndDeflector, INormalSpace, INitrinoParticleNebulae, IHighDensitySpaceNebulae
{
    public VaklasShip(bool havePhotons)
    {
        Hull = new HullSecond();
        ImpulseEngine = new EImpulseEngine();
        JumpEngine = new GammaJumpEngine();
        Deflector = new DeflectorFirst(havePhotons);
        Weight = Hull.PartWeight + ImpulseEngine.PartWeight + JumpEngine.PartWeight + Deflector.PartWeight;
    }
}