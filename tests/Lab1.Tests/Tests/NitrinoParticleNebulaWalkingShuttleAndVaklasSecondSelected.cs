using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class NitrinoParticleNebulaWalkingShuttleAndVaklasSecondSelected
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
                    new Vaklas(null),
                },
                new List<SpaceBase>
                {
                    new HighDensityNebulaeSpace(500, new Collection<ObstaclesBase>()),
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
    [MemberData(nameof(GetShipsAndSpaces), MemberType = typeof(NitrinoParticleNebulaWalkingShuttleAndVaklasSecondSelected))]

    private void ConditionCheck(List<ShipBase> manyShips, List<SpaceBase> manySpaces)
    {
        Assert.True(CheckLaunchResults(manyShips, manySpaces));
    }
}