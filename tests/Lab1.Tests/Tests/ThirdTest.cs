using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class ThirdTest
{
    private static bool CheckResult(IList<BaseShip> manyShips, IList<BaseSpace> manySpaces)
    {
        var service = new MainService();

        var checkList = new List<List<string>>(service.MainLaunch(manyShips, manySpaces).Select(x => x.ToList()));
        const string checkFirst = "ShipDestroyed";
        const string checkSecond = "DeflectorDestroyed";
        const string checkThird = "Successfully";

        bool result = checkFirst.Equals(checkList[0][1], StringComparison.Ordinal);
        result &= checkSecond.Equals(checkList[1][1], StringComparison.Ordinal);
        result &= checkThird.Equals(checkList[2][1], StringComparison.Ordinal);

        return result;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]

    private void ConditionCheck(BaseShip vaklasShip, BaseShip augurShip, BaseShip meredianShip)
    {
        var manyShips = new List<BaseShip>
        {
            vaklasShip,
            augurShip,
            meredianShip,
        };

        var obstacles = new Collection<BaseObstacles> { new SpaceWhales() };
        var obstaclesCounter = new Collection<int> { 4 };
        var manySpaces = new List<BaseSpace> { new NitrinoParticleNebulae(10, obstaclesCounter, obstacles) };

        Assert.True(CheckResult(manyShips, manySpaces));
    }

    private class ParameterizedTests : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new VaklasShip(false),
                new AugurShip(false),
                new MeredianShip(false),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}