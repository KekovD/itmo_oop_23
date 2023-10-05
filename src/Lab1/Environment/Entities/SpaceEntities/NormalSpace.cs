﻿using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.ObstaclesEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.SpaceEntities;

public class NormalSpace : BaseNormalSpace
{
    public NormalSpace(int routeLength, int numberOfObstaclesOnRoute, int secondNumberOfObstaclesOnRoute)
    {
        TypeOfSpace = ExistingTypesOfSpace.NormalSpace;
        RouteLength = routeLength;
        NumberOfObstaclesOnRoute = numberOfObstaclesOnRoute;
        TypeOfObstacles = new SmallAsteroids();
        SecondNumberOfObstaclesOnRoute = secondNumberOfObstaclesOnRoute;
        TypeOfSecondObstacles = new Meteorites();
    }
}