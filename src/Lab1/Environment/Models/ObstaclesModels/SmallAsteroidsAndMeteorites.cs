using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

public abstract class SmallAsteroidsAndMeteorites : StandardObstacles
{
    public override void DoingDamage(BaseShip ship, int damage)
    {
        if (ship is BaseShipWithDeflector derivedShip)
        {
            if (derivedShip.ShipDeflector.Serviceability)
            {
                derivedShip.ShipDeflector.SetHealthOfDeflector(derivedShip.ShipDeflector.HealthOfDeflector - damage);
                return;
            }

            derivedShip.ShipHull.SetHealthOfHull(derivedShip.ShipHull.HealthOfHull - damage);
            derivedShip.SetShipAlive();
            return;
        }

        ship.ShipHull.SetHealthOfHull(ship.ShipHull.HealthOfHull - damage);
        ship.SetShipAlive();
    }
}