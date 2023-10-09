using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;

public class NormalSpace : BaseSpace, INormalSpace
{
    public NormalSpace(int routeLength, IEnumerable<int> numberOfObstaclesOnRoute)
    {
        RouteLength = routeLength;
        NumberOfObstaclesOnRoute = new List<int>(numberOfObstaclesOnRoute);
        TypeOfObstacles = new Collection<BaseObstacles>();
        var obstaclesFirst = new SmallAsteroids();
        var obstaclesSecond = new Meteorites();
        TypeOfObstacles.Add(obstaclesFirst);
        TypeOfObstacles.Add(obstaclesSecond);
        if (NumberOfObstaclesOnRoute.Count != TypeOfObstacles.Count)
        {
            throw new DifferentLengthCollectionsWhenCreatingSpaceException(nameof(NormalSpace));
        }
    }
}