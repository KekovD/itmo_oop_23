using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.ObstaclesEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.SpaceEntities;

public class NitrinoParticleNebulae : BaseNitrinoParticleNebulae
{
    public NitrinoParticleNebulae(int routeLength, int numberOfObstaclesOnRoute)
    {
        TypeOfSpace = ExistingTypesOfSpace.NitrinoParticleNebulae;
        RouteLength = routeLength;
        NumberOfObstaclesOnRoute = numberOfObstaclesOnRoute;
        TypeOfObstacles = new SpaceWhales();
    }
}