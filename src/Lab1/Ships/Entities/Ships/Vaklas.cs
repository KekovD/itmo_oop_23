﻿using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Jump;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Ships;

public class Vaklas : ShipWithJumpEngineAndDeflectorBase
{
    public Vaklas(IAdditionalEquipment? additionalEquipment)
    {
        if (additionalEquipment is PhotonsDeflectors)
        {
            AdditionalEquipment = new List<IAdditionalEquipment> { additionalEquipment };
        }

        Hull = new ThirdHull();
        ImpulseEngine = new EImpulse();
        JumpEngine = new GammaJump();
        Deflector = new FirstDeflector();
        Weight = Hull.PartWeight + ImpulseEngine.PartWeight + JumpEngine.PartWeight + Deflector.PartWeight;
    }
}