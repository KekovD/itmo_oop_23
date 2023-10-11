using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Ships;

public class Meredian : ShipWithDeflectorBase
{
    public Meredian(IAdditionalEquipment? additionalEquipment)
    {
        Hull = new ThirdHull();
        ImpulseEngine = new EImpulse();
        Deflector = new SecondDeflector();
        AdditionalEquipment = new List<IAdditionalEquipment> { new AntiNitrinoEmitter() };
        Weight = Hull.PartWeight + ImpulseEngine.PartWeight + Deflector.PartWeight;

        if (additionalEquipment is PhotonsDeflectors)
        {
            AdditionalEquipment = new List<IAdditionalEquipment> { additionalEquipment, new AntiNitrinoEmitter() };
        }
    }
}