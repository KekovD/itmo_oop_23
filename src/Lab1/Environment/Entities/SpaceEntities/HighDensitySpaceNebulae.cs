using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.ObstaclesEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.SpaceEntities;

public class HighDensitySpaceNebulae : BaseHighDensitySpaceNebulae
{
    public HighDensitySpaceNebulae(int routeLength, int numberOfObstaclesOnRoute)
    {
        TypeOfSpace = ExistingTypesOfSpace.HighDensitySpaceNebulae;
        RouteLength = routeLength;
        NumberOfObstaclesOnRoute = numberOfObstaclesOnRoute;
        TypeOfObstacles = new AntimatterFlash();
    }
}