using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class WalkingShuttleAndAugurNoJumpEnginesAndInsufficientRangeAllNoCompleteRoute
{
    private static bool CheckResult(IList<ShipBase> manyShips, IList<SpaceBase> manySpaces)
    {
        var service = new MainService();

        (IList<WhatHappenedStatus> LaunchResults, WhatHappenedStatus OptimumShipExists, int OptimalShip)
            check = service.MainLaunch(manyShips, manySpaces);

        bool result = check.LaunchResults[0] == WhatHappenedStatus.NoJumpEngine &&
                      check.LaunchResults[1] == WhatHappenedStatus.ShortJumpRange;

        return result;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]

    private void ConditionCheck(ShipBase walkingShuttle, ShipBase augur)
    {
        var manyShips = new List<ShipBase>
        {
            walkingShuttle,
            augur,
        };

        var obstacles = new Collection<ObstaclesBase> { new AntimatterFlash(1) };
        var manySpaces = new List<SpaceBase> { new HighDensityNebulaeSpace(10000, obstacles) };

        Assert.True(CheckResult(manyShips, manySpaces));
    }

    private class ParameterizedTests : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new WalkingShuttle(),
                new Augur(null),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}