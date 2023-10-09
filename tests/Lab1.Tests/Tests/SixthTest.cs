﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class SixthTest
{
    private static bool CheckResult(IList<BaseShip> manyShips, IList<BaseSpace> manySpaces)
    {
        var service = new MainService();

        var checkList = new List<List<string>>(service.MainLaunch(manyShips, manySpaces).Select(x => x.ToList()));
        const string checkFirst = "VaklasShip";

        bool result = checkFirst.Equals(checkList[2][0], StringComparison.Ordinal);

        return result;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]

    private void ConditionCheck(BaseShip walkingShuttleShip, BaseShip vaklasShip)
    {
        var manyShips = new List<BaseShip>
        {
            walkingShuttleShip,
            vaklasShip,
        };

        var obstacles = new Collection<BaseObstacles>();
        var obstaclesCounter = new Collection<int>();
        var manySpaces = new List<BaseSpace> { new HighDensitySpaceNebulae(500, obstaclesCounter, obstacles) };

        Assert.True(CheckResult(manyShips, manySpaces));
    }

    private class ParameterizedTests : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new WalkingShuttleShip(),
                new VaklasShip(false),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}