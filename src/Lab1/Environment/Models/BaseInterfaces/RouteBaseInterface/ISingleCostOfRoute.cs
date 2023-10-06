﻿using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;

public interface ISingleCostOfRoute
{
    int GetSingleCostOfRoute(BaseShip ship, BaseSpace space, int distance);
}