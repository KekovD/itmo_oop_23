﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class SecondTest
{
    private static bool CheckResult(IList<BaseShip> manyShips, IList<BaseSpace> manySpaces)
    {
        var service = new MainService();
        var checkList = new List<List<string>>(service.MainLaunch(manyShips, manySpaces).Select(x => x.ToList()));
        const string checkFirst = "CrewKilled";
        const string checkSecond = "Successfully";
        bool result = checkFirst.Equals(checkList[0][1], StringComparison.Ordinal);
        result &= checkSecond.Equals(checkList[1][1], StringComparison.Ordinal);
        return result;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]

    private void ConditionCheck(BaseShip vaklasShipWithoutPhotons, BaseShip vaklasShipWithPhotons)
    {
        var manyShips = new List<BaseShip>
        {
            vaklasShipWithoutPhotons,
            vaklasShipWithPhotons,
        };
        var obstacles = new Collection<int>();
        obstacles.Add(3);
        var space = new HighDensitySpaceNebulae(100, obstacles);
        var manySpaces = new List<BaseSpace>();
        manySpaces.Add(space);
        Assert.True(CheckResult(manyShips, manySpaces));
    }

    private class ParameterizedTests : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new VaklasShip(false),
                new VaklasShip(true),
            },
        };
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}