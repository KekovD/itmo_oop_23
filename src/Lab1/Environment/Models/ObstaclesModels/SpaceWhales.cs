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

        if (ship is BaseShipWithDeflector derivedShip)
        {
            if (derivedShip.ShipDeflector.DeflectAntimatterFlares)
            {
                derivedShip.ShipDeflector.SetHealthOfPhotonsDeflector(derivedShip.ShipDeflector.PhotonsHealth - damage);
            }

            if (derivedShip.ShipDeflector.Serviceability)
            {
                derivedShip.ShipDeflector.SetHealthOfDeflector(derivedShip.ShipDeflector.HealthOfDeflector - damage);
            }

            return;
        }

        ship.ShipHull.SetHealthOfHull(ship.ShipHull.HealthOfHull - damage);
        ship.SetShipAlive();
    }
}