﻿using System.Collections.Generic;
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
    public static IEnumerable<object[]> GetShipsAndSpaces
    {
        get
        {
            yield return new object[]
            {
                new List<ShipBase>
                {
                    new WalkingShuttle(),
                    new Meredian(null),
                    new Stella(new PhotonsDeflectors()),
                },
                new List<SpaceBase>
                {
                    new NormalSpace(1000, new Collection<ObstaclesBase>
                    {
                        new SmallAsteroids(4),
                        new Meteorites(2),
                    }),
                    new NitrinoParticleNebulaeSpace(500, new Collection<ObstaclesBase>
                    {
                        new SpaceWhales(3),
                    }),
                },
            };
        }
    }

    private static bool CheckLaunchResults(IList<ShipBase> manyShips, IList<SpaceBase> manySpaces)
    {
        var service = new MainService();

        (IEnumerable<WhatHappenedStatus> LaunchResults, WhatHappenedStatus OptimumShipExists, int OptimalShip)
            check = service.MainLaunch(manyShips, manySpaces);

        bool result = check is { OptimumShipExists: WhatHappenedStatus.OptimalShipExists, OptimalShip: 1 };

        return result;
    }

    [Theory]
    [MemberData(nameof(GetShipsAndSpaces), MemberType = typeof(NormalSpaceAndNitrinoParticleNebulaeWalkingShuttleMeredianStellaSecondSelected))]

    private void ConditionCheck(List<ShipBase> manyShips, List<SpaceBase> manySpaces)
    {
        Assert.True(CheckLaunchResults(manyShips, manySpaces));
    }
}