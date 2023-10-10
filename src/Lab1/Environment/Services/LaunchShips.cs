﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Other;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Impulse;
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
                TryTraverseRouteDamage(ship, segment, segment.RouteLength);
                if (!segment.TryTraverseRouteDistance(ship, segment.RouteLength))
                {
                    checkAdd = false;
                }
            }

            resultCollection.Add(checkAdd);
        }

        return resultCollection;
    }

    public bool TryTraverseRouteDamage(BaseShip ship, BaseSpace space, int distance)
    {
        if (space is NormalSpace derivedSpace)
        {
            if (derivedSpace.TypeOfObstacles == null)
            {
                throw new PartOfSpaceNullException(nameof(derivedSpace.TypeOfObstacles));
            }

            if (derivedSpace.NumberOfObstaclesOnRoute == null)
            {
                throw new PartOfSpaceNullException(nameof(derivedSpace.NumberOfObstaclesOnRoute));
            }

            int iterator = 0;
            int counterObstacles = 0;
            foreach (BaseObstacles obstacles in derivedSpace.TypeOfObstacles)
            {
                for (int i = 1; i < derivedSpace.NumberOfObstaclesOnRoute[iterator]; i++)
                {
                    obstacles.DoingDamage(ship);
                    counterObstacles++;
                    if (ship.ShipAlive == false)
                    {
                        derivedSpace.SetNumberOfObstacles(
                            derivedSpace.NumberOfObstaclesOnRoute[iterator] - counterObstacles, iterator);
                        return false;
                    }
                }

                derivedSpace.SetNumberOfObstacles(
                    derivedSpace.NumberOfObstaclesOnRoute[iterator] - counterObstacles, iterator);
                counterObstacles = 0;

                iterator++;
            }

            if (ship.ShipAlive == false)
            {
                return false;
            }

            return true;
        }

        if (space is HighDensitySpaceNebulae derivedSpaceSecond)
        {
            if (ship is BaseShipWithJumpEngineAndDeflector derivedShip)
            {
                if (derivedSpaceSecond.TypeOfObstacles == null)
                {
                    throw new PartOfSpaceNullException(nameof(derivedSpaceSecond.TypeOfObstacles));
                }

                if (derivedSpaceSecond.NumberOfObstaclesOnRoute == null)
                {
                    throw new PartOfSpaceNullException(nameof(derivedSpace.NumberOfObstaclesOnRoute));
                }

                int iterator = 0;
                int counterObstacles = 0;
                foreach (BaseObstacles obstacles in derivedSpaceSecond.TypeOfObstacles)
                {
                    for (int i = 1; i < derivedSpaceSecond.NumberOfObstaclesOnRoute[iterator]; i++)
                    {
                        obstacles.DoingDamage(derivedShip);
                        counterObstacles++;
                        if (ship.ShipAlive == false)
                        {
                            derivedSpaceSecond.SetNumberOfObstacles(
                                derivedSpaceSecond.NumberOfObstaclesOnRoute[iterator] - counterObstacles, iterator);
                            return false;
                        }
                    }

                    derivedSpaceSecond.SetNumberOfObstacles(
                        derivedSpaceSecond.NumberOfObstaclesOnRoute[iterator] - counterObstacles, iterator);
                    counterObstacles = 0;

                    iterator++;
                }

                if (derivedShip.ShipAlive == false)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        if (space is NitrinoParticleNebulae derivedSpaceThird)
        {
            if (derivedSpaceThird.TypeOfObstacles == null)
            {
                throw new PartOfSpaceNullException(nameof(derivedSpaceThird.TypeOfObstacles));
            }

            if (derivedSpaceThird.NumberOfObstaclesOnRoute == null)
            {
                throw new PartOfSpaceNullException(nameof(derivedSpaceThird.NumberOfObstaclesOnRoute));
            }

            int iterator = 0;
            int counterObstacles = 0;
            foreach (BaseObstacles obstacles in derivedSpaceThird.TypeOfObstacles)
            {
                if (ship.AdditionalEquipment.Any(equipment => equipment is AntiNitrinoEmitter) == false &&
                    derivedSpaceThird.NumberOfObstaclesOnRoute[iterator] != 0)
                {
                    for (int i = 1; i < derivedSpaceThird.NumberOfObstaclesOnRoute[iterator]; i++)
                    {
                        obstacles.DoingDamage(ship);
                        counterObstacles++;
                        if (ship.ShipAlive == false)
                        {
                            derivedSpaceThird.SetNumberOfObstacles(
                                derivedSpaceThird.NumberOfObstaclesOnRoute[iterator] - counterObstacles, iterator);
                            return false;
                        }
                    }

                    derivedSpaceThird.SetNumberOfObstacles(
                        derivedSpaceThird.NumberOfObstaclesOnRoute[iterator] - counterObstacles, iterator);
                    counterObstacles = 0;
                }

                iterator++;
            }

            if (ship.ShipAlive == false)
            {
                return false;
            }

            return true;
        }

        throw new ServicesInvalidOperationException(nameof(TryTraverseRouteDamage));
    }

    public int GetSingleCostOfRoute(BaseShip ship, BaseSpace space, int distance, FuelExchange fuelExchange)
    {
        const int wrongTypeOfEngineRatio = 100000;
        if (space is INormalSpace)
        {
            return ship.ImpulseFuelPrice(distance, fuelExchange);
        }

        if (space is IHighDensitySpaceNebulae)
        {
            if (ship is BaseShipWithJumpEngineAndDeflector derivedShip)
            {
                return derivedShip.JumpFuelPrice(distance, fuelExchange);
            }

            return ship.ImpulseFuelPrice(distance, fuelExchange) * wrongTypeOfEngineRatio;
        }

        if (space is INitrinoParticleNebulae)
        {
            if (ship.ImpulseEngine is CImpulseEngine)
            {
                return ship.ImpulseFuelPrice(distance, fuelExchange) * wrongTypeOfEngineRatio;
            }

            return ship.ImpulseFuelPrice(distance, fuelExchange);
        }

        throw new ServicesInvalidOperationException(nameof(GetSingleCostOfRoute));
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
                int segmentCost = GetSingleCostOfRoute(ship, segment, segment.RouteLength, fuelExchange);
                totalCost += segmentCost;
            }

            survivorsCost.Add(totalCost);
        }

        foreach (BaseShip ship in allShips)
        {
            int totalCost = 0;

            foreach (BaseSpace segment in manySegments)
            {
                int segmentCost = GetSingleCostOfRoute(ship, segment, segment.RouteLength, fuelExchange);
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
        if (!ship.CrewAlive)
        {
            return WhatHappenedStatus.CrewKilled;
        }

        if (ship.Hull == null)
        {
            throw new PartOfShipNullException(nameof(ship.Hull));
        }

        if (!ship.Hull.Serviceability)
        {
            return WhatHappenedStatus.ShipDestroyed;
        }

        if (ship is BaseShipWithJumpEngineAndDeflector { EnoughDistanceJumpStatus: false })
        {
            return WhatHappenedStatus.ShortJumpRange;
        }

        if (ship is BaseShipWithDeflector { Deflector.Serviceability: false })
        {
            return WhatHappenedStatus.DeflectorDestroyed;
        }

        if (ship.NoJumpEngineStatus == false)
        {
            return WhatHappenedStatus.NoJumpEngine;
        }

        return WhatHappenedStatus.Successfully;
    }

    public abstract (IList<WhatHappenedStatus> LaunchResults, WhatHappenedStatus OptimumShipExists, int
        OptimalShip) MainLaunch(IList<BaseShip> manyShips, IList<BaseSpace> manySpaces);
}