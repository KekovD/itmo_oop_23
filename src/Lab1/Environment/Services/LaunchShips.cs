using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public Collection<bool> TryLaunchShips(IEnumerable<ShipBase> manyShips, ICollection<SpaceBase> manySegments)
    {
        var resultCollection = new Collection<bool>();

        foreach (ShipBase ship in manyShips)
        {
            bool checkAdd = true;
            foreach (SpaceBase segment in manySegments)
            {
                segment.TraverseRouteDamage(ship);
                if (!segment.TryTraverseRouteDistance(ship, segment.RouteLength))
                {
                    checkAdd = false;
                }
            }

            resultCollection.Add(checkAdd);
        }

        return resultCollection;
    }

    public int GetOptimumShip(IEnumerable<ShipBase> survivorsShips, IEnumerable<ShipBase> allShips, ICollection<SpaceBase> manySegments)
    {
        var survivorsCost = new List<int>();
        var allCost = new List<int>();
        var fuelExchange = new FuelExchange();

        foreach (ShipBase ship in survivorsShips)
        {
            int totalCost = 0;

            foreach (SpaceBase segment in manySegments)
            {
                int segmentCost = ship.CostOfRoute(segment, segment.RouteLength, fuelExchange);
                totalCost += segmentCost;
            }

            survivorsCost.Add(totalCost);
        }

        foreach (ShipBase ship in allShips)
        {
            int totalCost = 0;

            foreach (SpaceBase segment in manySegments)
            {
                int segmentCost = ship.CostOfRoute(segment, segment.RouteLength, fuelExchange);
                totalCost += segmentCost;
            }

            allCost.Add(totalCost);
        }

        int minimumPrice = survivorsCost.Min();
        int minimumPriseIndex = allCost.IndexOf(minimumPrice);
        return minimumPriseIndex;
    }

    public WhatHappenedStatus CheckWhatHappened(ShipBase ship)
    {
        if (!ship.CrewAlive) return WhatHappenedStatus.CrewKilled;

        if (ship.Hull == null) throw new PartOfShipNullException(nameof(ship.Hull));

        if (!ship.Hull.Serviceability) return WhatHappenedStatus.ShipDestroyed;

        if (ship is ShipWithJumpEngineAndDeflectorBase { EnoughDistanceJumpStatus: false })
            return WhatHappenedStatus.ShortJumpRange;

        if (ship is ShipWithDeflectorBase { Deflector.Serviceability: false })
            return WhatHappenedStatus.DeflectorDestroyed;

        if (ship.NoJumpEngineStatus == false) return WhatHappenedStatus.NoJumpEngine;

        return WhatHappenedStatus.Successfully;
    }

    public abstract (IList<WhatHappenedStatus> LaunchResults, WhatHappenedStatus OptimumShipExists, int
        OptimalShip) MainLaunch(IList<ShipBase> manyShips, IList<SpaceBase> manySpaces);
}