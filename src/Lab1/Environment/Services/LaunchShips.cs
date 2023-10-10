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
    public Collection<bool> TryLaunchShips(IEnumerable<BaseShip> manyShips, ICollection<BaseSpace> manySegments)
    {
        var resultCollection = new Collection<bool>();

        foreach (BaseShip ship in manyShips)
        {
            bool checkAdd = true;
            foreach (BaseSpace segment in manySegments)
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

    public int GetOptimumShip(IEnumerable<BaseShip> survivorsShips, IEnumerable<BaseShip> allShips, ICollection<BaseSpace> manySegments)
    {
        var survivorsCost = new List<int>();
        var allCost = new List<int>();
        var fuelExchange = new FuelExchange();

        foreach (BaseShip ship in survivorsShips)
        {
            int totalCost = 0;

            foreach (BaseSpace segment in manySegments)
            {
                int segmentCost = ship.CostOfRoute(segment, segment.RouteLength, fuelExchange);
                totalCost += segmentCost;
            }

            survivorsCost.Add(totalCost);
        }

        foreach (BaseShip ship in allShips)
        {
            int totalCost = 0;

            foreach (BaseSpace segment in manySegments)
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

    public WhatHappenedStatus CheckWhatHappened(BaseShip ship)
    {
        if (!ship.CrewAlive) return WhatHappenedStatus.CrewKilled;

        if (ship.Hull == null) throw new PartOfShipNullException(nameof(ship.Hull));

        if (!ship.Hull.Serviceability) return WhatHappenedStatus.ShipDestroyed;

        if (ship is BaseShipWithJumpEngineAndDeflector { EnoughDistanceJumpStatus: false })
            return WhatHappenedStatus.ShortJumpRange;

        if (ship is BaseShipWithDeflector { Deflector.Serviceability: false })
            return WhatHappenedStatus.DeflectorDestroyed;

        if (ship.NoJumpEngineStatus == false) return WhatHappenedStatus.NoJumpEngine;

        return WhatHappenedStatus.Successfully;
    }

    public abstract (IList<WhatHappenedStatus> LaunchResults, WhatHappenedStatus OptimumShipExists, int
        OptimalShip) MainLaunch(IList<BaseShip> manyShips, IList<BaseSpace> manySpaces);
}