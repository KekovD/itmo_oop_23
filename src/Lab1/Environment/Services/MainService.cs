using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class MainService : LaunchShips, IMainLaunch
{
    public IList<IList<string>> MainLaunch(IList<BaseShip> manyShips, IList<BaseSpace> manySpaces)
    {
        Collection<bool> resultLaunch = TryLaunchShips(manyShips, manySpaces);
        var resultMainLaunch = new List<IList<string>>();
        var allShips = new List<BaseShip>(manyShips);

        int iterator = 0;
        foreach (bool shipResult in resultLaunch)
        {
            string shipName = allShips[iterator].GetType().Name;
            string shipResultString = GetWhatHappenedName(CheckWhatHappened(allShips[iterator]));
            var shipInfo = new List<string> { shipName, shipResultString };

            resultMainLaunch.Add(shipInfo);

            if ((shipResult && CheckWhatHappened(allShips[iterator]) != WhatHappenedStatus.Successfully) &&
                (shipResult && CheckWhatHappened(allShips[iterator]) != WhatHappenedStatus.DeflectorDestroyed))
            {
                throw new ServicesInvalidOperationException(nameof(MainLaunch));
            }

            iterator++;
        }

        var falseIndex = new List<int>();
        int iteratorSecond = 0;
        foreach (bool result in resultLaunch)
        {
            if (result == false)
            {
                falseIndex.Add(iteratorSecond);
            }

            iteratorSecond++;
        }

        foreach (int i in falseIndex)
        {
            allShips.RemoveAt(i);
        }

        int resultPrefer = GetOptimumShip(allShips, manySpaces);
        string shipNamePrefer = allShips[resultPrefer].GetType().Name;
        var shipInfoPrefer = new List<string> { shipNamePrefer, shipNamePrefer };
        resultMainLaunch.Add(shipInfoPrefer);

        return resultMainLaunch;
    }
}