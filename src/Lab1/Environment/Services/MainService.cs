using System.Collections.Generic;
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
        var resultMainLaunch = new List<WhatHappenedStatus>();
        var allShips = new List<ShipBase>(manyShips);

        int iterator = 0;
        foreach (bool shipResult in resultLaunch)
        {
            resultMainLaunch.Add(CheckWhatHappened(allShips[iterator]));

            iterator++;
        }

        var falseIndex = new List<int>();
        int iteratorSecond = 0;
        foreach (bool result in resultLaunch)
        {
            if (result == false)
                falseIndex.Add(iteratorSecond);

            iteratorSecond++;
        }

        int countIteration = 0;
        var survivorsShips = new List<ShipBase>(allShips);
        foreach (int i in falseIndex)
        {
            survivorsShips.RemoveAt(i - countIteration);
            countIteration++;
        }

        if (survivorsShips.Count == 0)
            return (resultMainLaunch, WhatHappenedStatus.NoSurvivingShips, (int)WhatHappenedStatus.NoSurvivingShips);

        int resultPrefer = GetOptimumShip(survivorsShips, allShips, manySpaces);

        return (resultMainLaunch, WhatHappenedStatus.OptimalShipExists, resultPrefer);
    }
}