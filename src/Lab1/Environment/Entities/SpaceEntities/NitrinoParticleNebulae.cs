using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.ObstaclesEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.SpaceEntities;

public class NitrinoParticleNebulae : BaseNitrinoParticleNebulae
{
    public NitrinoParticleNebulae(int routeLength, Collection<int> numberOfObstaclesOnRoute)
    {
        TypeOfSpace = ExistingTypesOfSpace.NitrinoParticleNebulae;
        RouteLength = routeLength;
        NumberOfObstaclesOnRoute = new List<int>(numberOfObstaclesOnRoute);
        TypeOfObstacles = new Collection<BaseStandardObstacles>();
        var obstaclesFirst = new SpaceWhales();
        TypeOfObstacles.Add(obstaclesFirst);
        if (NumberOfObstaclesOnRoute.Count != TypeOfObstacles.Count)
        {
            throw new DifferentLengthCollectionsWhenCreatingSpaceException(nameof(NitrinoParticleNebulae));
        }
    }
}