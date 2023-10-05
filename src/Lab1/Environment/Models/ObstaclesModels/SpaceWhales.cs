using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

public abstract class SpaceWhales : AntimatterFlashes
{
    public override void DoingDamage(BaseShip ship, int damage)
    {
        if (ship.ShipAntiNitrinoEmitter)
        {
            return;
        }

        ship.ShipHull.SetHealthOfHull(ship.ShipHull.HealthOfHull - (int)ObstructionDamage.SpaceWhaleDamage);
        ship.SetShipAlive();
    }
}