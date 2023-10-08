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

public class FifthTest
{
    private static bool CheckResult(IList<BaseShip> manyShips, IList<BaseSpace> manySpaces)
    {
        var service = new MainService();
        var checkList = new List<List<string>>(service.MainLaunch(manyShips, manySpaces).Select(x => x.ToList()));
        const string checkFirst = "StellaShip";
        bool result = checkFirst.Equals(checkList[2][0], StringComparison.Ordinal);
        return result;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]

    private void ConditionCheck(BaseShip augurShip, BaseShip stellaShip)
    {
        var manyShips = new List<BaseShip>
        {
            augurShip,
            stellaShip,
        };
        var obstacles = new Collection<int>();
        obstacles.Add(2);
        var space = new HighDensitySpaceNebulae(2000, obstacles);
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
                new AugurShip(true),
                new StellaShip(true),
            },
        };
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}