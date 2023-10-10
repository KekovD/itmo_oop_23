using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;

public class NormalSpace : BaseSpace, INormalSpace
{
    public NormalSpace(int routeLength, IEnumerable<int> numberOfObstaclesOnRoute, IEnumerable<BaseObstacles> manyObstacles)
        : base(routeLength)
    {
        NumberOfObstaclesOnRoute = new List<int>(numberOfObstaclesOnRoute);
        TypeOfObstacles = new Collection<BaseObstacles>();

        foreach (BaseObstacles obstacle in manyObstacles)
        {
            if (obstacle is not INormalSpace)
            {
                throw new ObstacleDoesNotMatchEnvironmentException(nameof(NormalSpace));
            }

            TypeOfObstacles.Add(obstacle);
        }

        if (NumberOfObstaclesOnRoute.Count != TypeOfObstacles.Count)
        {
            throw new DifferentLengthCollectionsWhenCreatingSpaceException(nameof(NormalSpace));
        }
    }

    public override bool TryTraverseRouteDistance(BaseShip ship, int distance)
    {
        if (ship is INormalSpace)
        {
            return true;
        }

        return false;
    }
}