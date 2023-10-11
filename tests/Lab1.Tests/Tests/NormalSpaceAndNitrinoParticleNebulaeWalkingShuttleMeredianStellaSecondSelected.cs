﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class NormalSpaceAndNitrinoParticleNebulaeWalkingShuttleMeredianStellaSecondSelected
{
    private static bool CheckResult(IList<ShipBase> manyShips, IList<SpaceBase> manySpaces)
    {
        var service = new MainService();

        (IEnumerable<WhatHappenedStatus> LaunchResults, WhatHappenedStatus OptimumShipExists, int OptimalShip)
            check = service.MainLaunch(manyShips, manySpaces);

        bool result = check is { OptimumShipExists: WhatHappenedStatus.OptimalShipExists, OptimalShip: 1 };

        return result;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]

    private void ConditionCheck(ShipBase walkingShuttle, ShipBase meredian, ShipBase stella)
    {
        var manyShips = new List<ShipBase>
        {
            walkingShuttle,
            meredian,
            stella,
        };

        var obstaclesCounter = new Collection<int>
        {
            4,
            2,
        };

        var obstacles = new Collection<ObstaclesBase>
        {
            new SmallAsteroids(),
            new Meteorites(),
        };

        var obstaclesSecondCounter = new Collection<int> { 3 };
        var obstaclesSecond = new Collection<ObstaclesBase> { new SpaceWhales() };

        var manySpaces = new List<SpaceBase>
        {
            new Normal(1000, obstaclesCounter, obstacles),
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
                new WalkingShuttle(),
                new Meredian(null),
                new Stella(new PhotonsDeflectors()),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}