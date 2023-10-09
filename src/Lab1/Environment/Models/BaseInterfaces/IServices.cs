﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;

public interface IServices
{
    bool TryTraverseRouteDistance(BaseShip ship, BaseSpace space, int distance);
    bool TryTraverseRouteDamage(BaseShip ship, BaseSpace space, int distance);
    int GetOptimumShip(IEnumerable<BaseShip> survivorsShips, IEnumerable<BaseShip> allShips, ICollection<BaseSpace> manySegments);
    WhatHappenedStatus CheckWhatHappened(BaseShip ship);
    int GetSingleCostOfRoute(BaseShip ship, BaseSpace space, int distance, IFuelExchange fuelExchange);
    Collection<bool> TryLaunchShips(IEnumerable<BaseShip> manyShips, ICollection<BaseSpace> manySegments);

    (IList<WhatHappenedStatus> LaunchResults, WhatHappenedStatus OptimumShipExists, int OptimalShip) MainLaunch(
        IList<BaseShip> manyShips, IList<BaseSpace> manySpaces);
}