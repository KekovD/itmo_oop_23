using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;

public class NitrinoParticleNebulaeSpace : SpaceBase
{
    public NitrinoParticleNebulaeSpace(int routeLength, IEnumerable<ObstaclesBase> manyObstacles)
        : base(routeLength)
    {
        TypeOfObstacles = new Collection<ObstaclesBase>(manyObstacles
            .Where(obstacle => obstacle is SpaceWhales)
            .ToList());
    }

    public override bool TryTraverseRouteDistance(ShipBase ship, int distance)
    {
        if (ship.ImpulseEngine is not EImpulse)
            return false;

        return true;
    }
}