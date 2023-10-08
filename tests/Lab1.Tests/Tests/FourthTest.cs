using System;
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

public class FourthTest
{
    private static bool CheckResult(IList<BaseShip> manyShips, IList<BaseSpace> manySpaces)
    {
        var service = new MainService();
        var checkList = new List<List<string>>(service.MainLaunch(manyShips, manySpaces).Select(x => x.ToList()));
        const string check = "WalkingShuttleShip";
        bool result = check.Equals(checkList[2][0], StringComparison.Ordinal);
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
        var obstacles = new Collection<int>();
        obstacles.Add(2);
        obstacles.Add(3);
        var space = new NormalSpace(100, obstacles);
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
                new VaklasShip(false),
            },
        };
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}