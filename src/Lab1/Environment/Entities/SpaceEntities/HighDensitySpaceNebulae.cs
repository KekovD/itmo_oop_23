using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.ObstaclesEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.SpaceEntities;

public class HighDensitySpaceNebulae : BaseHighDensitySpaceNebulae
{
    public HighDensitySpaceNebulae(int routeLength, Collection<int> numberOfObstaclesOnRoute)
    {
        RouteLength = routeLength;
        NumberOfObstaclesOnRoute = new List<int>(numberOfObstaclesOnRoute);
        TypeOfObstacles = new Collection<BaseObstacles>();
        var obstaclesFirst = new AntimatterFlash();
        TypeOfObstacles.Add(obstaclesFirst);
        if (NumberOfObstaclesOnRoute.Count != TypeOfObstacles.Count)
        {
            throw new DifferentLengthCollectionsWhenCreatingSpaceException(nameof(HighDensitySpaceNebulae));
        }
    }
}