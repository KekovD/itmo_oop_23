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

public class SeventhTest
{
    private static bool CheckResult(IList<BaseShip> manyShips, IList<BaseSpace> manySpaces)
    {
        var service = new MainService();

        var checkList = new List<List<string>>(service.MainLaunch(manyShips, manySpaces).Select(x => x.ToList()));
        const string checkFirst = "MeredianShip";

        bool result = checkFirst.Equals(checkList[3][0], StringComparison.Ordinal);

        return result;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]

    private void ConditionCheck(BaseShip walkingShuttleShip, BaseShip meredianShip, BaseShip stellaShip)
    {
        var manyShips = new List<BaseShip>
        {
            walkingShuttleShip,
            meredianShip,
            stellaShip,
        };

        var obstaclesCounter = new Collection<int>
        {
            4,
            2,
        };

        var obstacles = new Collection<BaseObstacles>
        {
            new SmallAsteroids(),
            new Meteorites(),
        };

        var obstaclesSecondCounter = new Collection<int> { 3 };
        var obstaclesSecond = new Collection<BaseObstacles> { new SpaceWhales() };

        var manySpaces = new List<BaseSpace>
        {
            new NormalSpace(1000, obstaclesCounter, obstacles),
            new NitrinoParticleNebulae(500, obstaclesSecondCounter, obstaclesSecond),
        };

        Assert.True(CheckResult(manyShips, manySpaces));
    }

    private class ParameterizedTests : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new WalkingShuttleShip(),
                new MeredianShip(false),
                new StellaShip(true),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}