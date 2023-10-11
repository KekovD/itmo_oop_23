using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;

public class HighDensityNebulaeSpace : SpaceBase, IHighDensitySpaceNebulae
{
    public HighDensityNebulaeSpace(int routeLength, IEnumerable<ObstaclesBase> manyObstacles)
        : base(routeLength)
    {
        TypeOfObstacles = new Collection<ObstaclesBase>();

        foreach (ObstaclesBase obstacle in manyObstacles)
        {
            if (obstacle is not IHighDensitySpaceNebulae)
                throw new ObstacleDoesNotMatchEnvironmentException(nameof(HighDensityNebulaeSpace));

            TypeOfObstacles.Add(obstacle);
        }
    }

    public override bool TryTraverseRouteDistance(ShipBase ship, int distance)
    {
        if (ship is not IHighDensitySpaceNebulae)
        {
            ship.SetFalseNoJumpStatus();
            return false;
        }

        return ship.TryOvercomeJumpDistance(distance);
    }
}