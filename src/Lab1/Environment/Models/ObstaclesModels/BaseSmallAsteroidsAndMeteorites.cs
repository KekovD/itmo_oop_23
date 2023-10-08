﻿using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

public abstract class BaseSmallAsteroidsAndMeteorites : BaseObstacles
{
    public override void DoingDamage(BaseShip ship)
    {
        if (ship.Hull == null)
        {
            throw new PartOfShipNullException(nameof(ship.Hull));
        }

        if (ship is BaseShipWithDeflector derivedShip)
        {
            if (derivedShip.Hull == null)
            {
                throw new PartOfShipNullException(nameof(ship.Hull));
            }

            if (derivedShip.Deflector.Serviceability)
            {
                derivedShip.Deflector.DamagingDeflector(StandardDamage);
                return;
            }

            derivedShip.Hull.DamagingHull(StandardDamage);
            derivedShip.CheckShipAlive();
            return;
        }

        ship.Hull.DamagingHull(StandardDamage);
        ship.CheckShipAlive();
    }
}