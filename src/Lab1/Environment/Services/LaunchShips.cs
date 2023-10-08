using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.SpaceEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public abstract class LaunchShips : IServicesInterface
{
    private const int WrongTypeOfEngineRatio = 100000;
    public Collection<bool> TryLaunchShips(ICollection<BaseShip> manyShips, ICollection<BaseSpace> manySegments)
    {
        var resultCollection = new Collection<bool>();

        foreach (BaseShip ship in manyShips)
        {
            bool checkAdd = true;
            foreach (BaseSpace segment in manySegments)
            {
                TryTraverseRouteDamage(ship, segment, segment.RouteLength);
                if (!TryTraverseRouteDistance(ship, segment, segment.RouteLength))
                {
                    checkAdd = false;
                }
            }

            resultCollection.Add(checkAdd);
        }

        return resultCollection;
    }

    public bool TryTraverseRouteDistance(BaseShip ship, BaseSpace space, int distance)
    {
        if (space is NormalSpace)
        {
            return true;
        }

        if (space is HighDensitySpaceNebulae)
        {
            if (ship is BaseShipWithJumpEngineAndDeflector derivedShip)
            {
                if (derivedShip.JumpEngine == null)
                {
                    throw new PartOfShipNullException(nameof(derivedShip.JumpEngine));
                }

                if (derivedShip.JumpEngine.JumpRage < distance)
                {
                    derivedShip.SetFalseEnoughDistanceJump();
                    return false;
                }

                return true;
            }

            ship.SetFalseNoJumpStatus();
            return false;
        }

        if (space is NitrinoParticleNebulae)
        {
            if (ship.ImpulseEngine is CImpulseEngine)
            {
                return false;
            }

            return true;
        }

        throw new ServicesInvalidOperationException(nameof(TryTraverseRouteDistance));
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
                if (ship.AntiNitrinoEmitter == false && derivedSpaceThird.NumberOfObstaclesOnRoute[iterator] != 0)
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

    public int GetSingleCostOfRoute(BaseShip ship, BaseSpace space, int distance)
    {
        if (space is NormalSpace)
        {
            return ship.ImpulseFuelPrice(distance);
        }

        if (space is HighDensitySpaceNebulae)
        {
            if (ship is BaseShipWithJumpEngineAndDeflector derivedShip)
            {
                return derivedShip.JumpFuelPrice(distance);
            }

            return ship.ImpulseFuelPrice(distance) * WrongTypeOfEngineRatio;
        }

        if (space is NitrinoParticleNebulae)
        {
            if (ship.ImpulseEngine is CImpulseEngine)
            {
                return ship.ImpulseFuelPrice(distance) * WrongTypeOfEngineRatio;
            }

            return ship.ImpulseFuelPrice(distance);
        }

        throw new ServicesInvalidOperationException(nameof(GetSingleCostOfRoute));
    }

    public int GetOptimumShip(IList<BaseShip> manyShips, ICollection<BaseSpace> manySegments)
    {
        var resultList = new List<int>();

        foreach (BaseShip ship in manyShips)
        {
            int totalCost = 0;

            foreach (BaseSpace segment in manySegments)
            {
                int segmentCost = GetSingleCostOfRoute(ship, segment, segment.RouteLength);
                totalCost += segmentCost;
            }

            resultList.Add(totalCost);
        }

        int minimumPrice = resultList.Min();
        int minimumPriseIndex = resultList.IndexOf(minimumPrice);
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

        if (ship is BaseShipWithJumpEngineAndDeflector { EnoughDistanceJump: false })
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

    public string GetWhatHappenedName(WhatHappenedStatus value)
    {
        string[] enumFieldNames = Enum.GetNames(typeof(WhatHappenedStatus));

        foreach (string fieldName in enumFieldNames)
        {
            var enumValue = (WhatHappenedStatus)Enum.Parse(typeof(WhatHappenedStatus), fieldName);

            if (enumValue == value)
            {
                return fieldName;
            }
        }

        throw new ServicesInvalidOperationException(nameof(GetWhatHappenedName));
    }

    public abstract IList<IList<string>> MainLaunch(IList<BaseShip> manyShips, IList<BaseSpace> manySpaces);
}