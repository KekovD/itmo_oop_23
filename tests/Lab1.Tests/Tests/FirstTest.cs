using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.SpaceEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.ShipsEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class FirstTest
{
    public static bool CheckResult(IList<BaseShip> manyShips, IList<BaseSpace> manySpaces)
    {
        var service = new MainService();
        var checkList = new List<List<string>>(service.MainLaunch(manyShips, manySpaces).Select(x => x.ToList()));
        string checkFirst = "NoJumpEngine";
        string checkSecond = "ShortJumpRange";
        bool result = checkFirst.Equals(checkList[0][1], StringComparison.Ordinal);
        result &= checkSecond.Equals(checkList[1][1], StringComparison.Ordinal);
        return result;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]

    public void AllNumbersAreOddWithClassData(BaseShip walkingShuttleShip, BaseShip augurShip)
    {
        var manyShips = new List<BaseShip>
        {
            walkingShuttleShip,
            augurShip,
        };
        var obstacles = new Collection<int>();
        obstacles.Add(1);
        var space = new HighDensitySpaceNebulae(10000, obstacles);
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
                new WalkingShuttleShip(),
                new AugurShip(false),
            },
        };
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}