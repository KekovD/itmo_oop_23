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

public class SpaceWhaleVaklasAugurAndMeredianDestroyedLostDeflectorsAndUntouched
{
    public static IEnumerable<object[]> GetShipsAndSpaces
    {
        get
        {
            yield return new object[]
            {
                new List<ShipBase>
                {
                    new Vaklas(null),
                    new Augur(null),
                    new Meredian(null),
                },
                new List<SpaceBase>
                {
                    new NitrinoParticleNebulaeSpace(10, new Collection<ObstaclesBase>
                    {
                        new SpaceWhales(4),
                    }),
                },
            };
        }
    }

    private static bool CheckLaunchResults(IList<ShipBase> manyShips, IList<SpaceBase> manySpaces)
    {
        var service = new MainService();

        (IList<WhatHappenedStatus> LaunchResults, WhatHappenedStatus OptimumShipExists, int OptimalShip)
            check = service.MainLaunch(manyShips, manySpaces);

        bool result = check.LaunchResults[0] == WhatHappenedStatus.ShipDestroyed &&
                      check.LaunchResults[1] == WhatHappenedStatus.DeflectorDestroyed &&
                      check.LaunchResults[2] == WhatHappenedStatus.Successfully;

        return result;
    }

    [Theory]
    [MemberData(nameof(GetShipsAndSpaces), MemberType = typeof(SpaceWhaleVaklasAugurAndMeredianDestroyedLostDeflectorsAndUntouched))]

    private void ConditionCheck(List<ShipBase> manyShips, List<SpaceBase> manySpaces)
    {
        Assert.True(CheckLaunchResults(manyShips, manySpaces));
    }
}