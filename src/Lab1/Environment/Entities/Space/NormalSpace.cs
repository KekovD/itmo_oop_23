using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;

public class NormalSpace : SpaceBase, INormalSpace
{
    public NormalSpace(int routeLength, IEnumerable<ObstaclesBase> manyObstacles)
        : base(routeLength)
    {
        TypeOfObstacles = new Collection<ObstaclesBase>();

        foreach (ObstaclesBase obstacle in manyObstacles)
        {
            if (obstacle is not INormalSpace)
                throw new ObstacleDoesNotMatchEnvironmentException(nameof(NormalSpace));

            TypeOfObstacles.Add(obstacle);
        }
    }

    public override bool TryTraverseRouteDistance(ShipBase ship, int distance)
    {
        if (ship is INormalSpace)
            return true;

        return false;
    }
}