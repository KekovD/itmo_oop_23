using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.SpaceEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
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
        var obstacles = new Collection<int>();
        obstacles.Add(4);
        obstacles.Add(2);
        var space = new NormalSpace(1000, obstacles);
        var obstaclesSecond = new Collection<int>();
        obstaclesSecond.Add(3);
        var spaceSecond = new NitrinoParticleNebulae(500, obstaclesSecond);
        var manySpaces = new List<BaseSpace>();
        manySpaces.Add(space);
        manySpaces.Add(spaceSecond);
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