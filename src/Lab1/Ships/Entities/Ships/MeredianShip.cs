using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Ships;

public class MeredianShip : BaseShipWithDeflector, INormalSpace, INitrinoParticleNebulae
{
    public MeredianShip(IAdditionalEquipment? additionalEquipment)
    {
        Hull = new HullSecond();
        ImpulseEngine = new EImpulseEngine();
        Deflector = new DeflectorSecond();
        AdditionalEquipment = new List<IAdditionalEquipment> { new AntiNitrinoEmitter() };
        Weight = Hull.PartWeight + ImpulseEngine.PartWeight + Deflector.PartWeight;

        if (additionalEquipment is PhotonsDeflectors)
        {
            AdditionalEquipment = new List<IAdditionalEquipment> { additionalEquipment, new AntiNitrinoEmitter() };
        }
    }
}