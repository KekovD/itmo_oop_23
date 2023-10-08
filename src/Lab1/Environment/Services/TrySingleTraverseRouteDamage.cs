using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.SpaceEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public abstract class TrySingleTraverseRouteDamage : WhatHappenedName, ITryTraverseRouteDamage
{
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
                if (ship.ShipAntiNitrinoEmitter == false && derivedSpaceThird.NumberOfObstaclesOnRoute[iterator] != 0)
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
}