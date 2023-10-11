using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;

public class Normal : SpaceBase, INormalSpace
{
    public Normal(int routeLength, IEnumerable<int> numberOfObstaclesOnRoute, IEnumerable<ObstaclesBase> manyObstacles)
        : base(routeLength)
    {
        NumberOfObstaclesOnRoute = new List<int>(numberOfObstaclesOnRoute);
        TypeOfObstacles = new Collection<ObstaclesBase>();

        foreach (ObstaclesBase obstacle in manyObstacles)
        {
            if (obstacle is not INormalSpace)
                throw new ObstacleDoesNotMatchEnvironmentException(nameof(Normal));

            TypeOfObstacles.Add(obstacle);
        }

        if (NumberOfObstaclesOnRoute.Count != TypeOfObstacles.Count)
            throw new DifferentLengthCollectionsWhenCreatingSpaceException(nameof(Normal));
    }

    public override bool TryTraverseRouteDistance(ShipBase ship, int distance)
    {
        if (ship is INormalSpace)
            return true;

        return false;
    }
}