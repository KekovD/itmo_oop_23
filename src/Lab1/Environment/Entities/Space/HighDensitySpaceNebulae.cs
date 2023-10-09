using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;

public class HighDensitySpaceNebulae : BaseSpace, IHighDensitySpaceNebulae
{
    public HighDensitySpaceNebulae(int routeLength, IEnumerable<int> numberOfObstaclesOnRoute, IEnumerable<BaseObstacles> manyObstacles)
        : base(routeLength)
    {
        NumberOfObstaclesOnRoute = new List<int>(numberOfObstaclesOnRoute);
        TypeOfObstacles = new Collection<BaseObstacles>();

        foreach (BaseObstacles obstacle in manyObstacles)
        {
            if (obstacle is not IHighDensitySpaceNebulae)
            {
                throw new ObstacleDoesNotMatchEnvironmentException(nameof(HighDensitySpaceNebulae));
            }

            TypeOfObstacles.Add(obstacle);
        }

        if (NumberOfObstaclesOnRoute.Count != TypeOfObstacles.Count)
        {
            throw new DifferentLengthCollectionsWhenCreatingSpaceException(nameof(HighDensitySpaceNebulae));
        }
    }
}