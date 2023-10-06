using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.ObstaclesEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.SpaceEntities;

public class NormalSpace : BaseNormalSpace
{
    public NormalSpace(int routeLength, Collection<int> numberOfObstaclesOnRoute)
    {
        TypeOfSpace = ExistingTypesOfSpace.NormalSpace;
        RouteLength = routeLength;
        NumberOfObstaclesOnRoute = new List<int>(numberOfObstaclesOnRoute);
        TypeOfObstacles = new Collection<BaseStandardObstacles>();
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