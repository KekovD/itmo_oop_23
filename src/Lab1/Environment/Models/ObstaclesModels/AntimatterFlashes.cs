﻿using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

public abstract class AntimatterFlashes : SmallAsteroidsAndMeteorites
{
    public override void DoingDamage(BaseShip ship, int damage)
    {
        if (ship is BaseShipWithDeflector { ShipDeflector.DeflectAntimatterFlares: true } derivedShip)
        {
            derivedShip.ShipDeflector.SetHealthOfPhotonsDeflector(derivedShip.ShipDeflector.PhotonsHealth - damage);
            return;
        }

        ship.KillCrew();
    }
}