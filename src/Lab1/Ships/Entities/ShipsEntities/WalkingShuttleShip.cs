﻿using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.HullEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.ShipsEntities;

public class WalkingShuttleShip : BaseShip
{
    public WalkingShuttleShip()
    {
        ShipHull = new HullFirst();
        ImpulseEngine = new CImpulseEngine();
        ShipWeight = ShipHull.PartWeight + ImpulseEngine.PartWeight;
    }
}