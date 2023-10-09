using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Jump;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Ships;

public class AugurShip : BaseShipWithJumpEngineAndDeflector, INormalSpace, INitrinoParticleNebulae, IHighDensitySpaceNebulae
{
    public AugurShip(bool havePhotons)
    {
        if (havePhotons)
        {
            AdditionalEquipment = new List<IAdditionalEquipment> { new PhotonsDeflectors() };
        }

        Hull = new HullThird();
        ImpulseEngine = new EImpulseEngine();
        JumpEngine = new AlphaJumpEngine();
        Deflector = new DeflectorThird();
        Weight = Hull.PartWeight + ImpulseEngine.PartWeight + JumpEngine.PartWeight + Deflector.PartWeight;
    }
}