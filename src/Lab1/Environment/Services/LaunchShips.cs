using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Other;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public abstract class LaunchShips : IServices
{
    public IEnumerable<bool> TryLaunchShips(IEnumerable<ShipBase> manyShips, ICollection<SpaceBase> manySegments)
    {
        return manyShips.Select(ship => manySegments
                .All(segment =>
            {
                segment.TraverseRouteDamage(ship);
                return segment.TryTraverseRouteDistance(ship, segment.RouteLength);
            }))
            .ToList();
    }

    public int GetOptimumShip(IEnumerable<ShipBase> survivorsShips, IEnumerable<ShipBase> allShips, ICollection<SpaceBase> manySegments)
    {
        var fuelExchange = new FuelExchange();

        var survivorsCost = survivorsShips
            .Select(ship => manySegments
                .Sum(segment =>
                    ship.CostOfRoute(segment, segment.RouteLength, fuelExchange)))
            .ToList();

        var allCost = allShips
            .Select(ship => manySegments
                .Sum(segment => ship
                    .CostOfRoute(segment, segment.RouteLength, fuelExchange)))
            .ToList();

        int minimumPrice = survivorsCost.Min();
        int minimumPriseIndex = allCost.IndexOf(minimumPrice);

        return minimumPriseIndex;
    }

    public WhatHappenedStatus CheckWhatHappened(ShipBase ship)
    {
        if (!ship.CrewAlive)
            return WhatHappenedStatus.CrewKilled;

        if (ship.Hull is null)
            throw new PartOfShipNullException(nameof(ship.Hull));

        if (!ship.Hull.Serviceability)
            return WhatHappenedStatus.ShipDestroyed;

        if (ship is ShipWithJumpEngineAndDeflectorBase { EnoughDistanceJumpStatus: false })
            return WhatHappenedStatus.ShortJumpRange;

        if (ship is ShipWithDeflectorBase { Deflector.Serviceability: false })
            return WhatHappenedStatus.DeflectorDestroyed;

        if (ship.NoJumpEngineStatus == false)
            return WhatHappenedStatus.NoJumpEngine;

        return WhatHappenedStatus.Successfully;
    }

    public abstract (IList<WhatHappenedStatus> LaunchResults, WhatHappenedStatus OptimumShipExists, int
        OptimalShip) MainLaunch(IList<ShipBase> manyShips, IList<SpaceBase> manySpaces);
}