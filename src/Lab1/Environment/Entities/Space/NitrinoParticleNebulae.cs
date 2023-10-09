using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using SpaceWhales = Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles.SpaceWhales;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;

public class NitrinoParticleNebulae : BaseSpace, INitrinoParticleNebulae
{
    public NitrinoParticleNebulae(int routeLength, IEnumerable<int> numberOfObstaclesOnRoute)
    {
        RouteLength = routeLength;
        NumberOfObstaclesOnRoute = new List<int>(numberOfObstaclesOnRoute);
        TypeOfObstacles = new Collection<BaseObstacles>();
        var obstaclesFirst = new SpaceWhales();
        TypeOfObstacles.Add(obstaclesFirst);
        if (NumberOfObstaclesOnRoute.Count != TypeOfObstacles.Count)
        {
            throw new DifferentLengthCollectionsWhenCreatingSpaceException(nameof(NitrinoParticleNebulae));
        }
    }
}