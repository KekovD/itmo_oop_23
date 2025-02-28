﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;

public class NormalSpace : SpaceBase
{
    public NormalSpace(int routeLength, IEnumerable<ObstaclesBase> manyObstacles)
        : base(routeLength)
    {
        TypeOfObstacles = new Collection<ObstaclesBase>(manyObstacles
            .Where(obstacle => obstacle is SmallAsteroids or Meteorites)
            .ToList());
    }

    public override bool TryTraverseRouteDistance(ShipBase ship, int distance)
    {
        if (ship is ShipBase)
            return true;

        return false;
    }
}