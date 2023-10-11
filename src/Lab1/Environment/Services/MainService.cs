using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class MainService : LaunchShips
{
    public override (IList<WhatHappenedStatus> LaunchResults, WhatHappenedStatus OptimumShipExists, int OptimalShip)
        MainLaunch(IList<ShipBase> manyShips, IList<SpaceBase> manySpaces)
    {
        var resultLaunch = new List<bool>(TryLaunchShips(manyShips, manySpaces));
        var allShips = new List<ShipBase>(manyShips);

        var resultMainLaunch = allShips
            .Select(CheckWhatHappened)
            .ToList();

        var defunctShipsIndexes = new List<int>();

        for (int i = 0; i < resultLaunch.Count; i++)
        {
            if (resultLaunch[i] == false)
                defunctShipsIndexes.Add(i);
        }

        var survivorsShips = allShips
            .Where((ship, index) => !defunctShipsIndexes.Contains(index))
            .ToList();

        if (survivorsShips.Count == 0)
            return (resultMainLaunch, WhatHappenedStatus.NoSurvivingShips, (int)WhatHappenedStatus.NoSurvivingShips);

        int resultPrefer = GetOptimumShip(survivorsShips, allShips, manySpaces);

        return (resultMainLaunch, WhatHappenedStatus.OptimalShipExists, resultPrefer);
    }
}