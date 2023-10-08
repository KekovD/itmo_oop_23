using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

public abstract class BaseSmallAsteroidsAndMeteorites : BaseObstacles
{
    public override void DoingDamage(BaseShip ship)
    {
        if (ship.ShipHull == null)
        {
            throw new PartOfShipNullException(nameof(ship.ShipHull));
        }

        if (ship is BaseShipWithDeflector derivedShip)
        {
            if (derivedShip.ShipHull == null)
            {
                throw new PartOfShipNullException(nameof(ship.ShipHull));
            }

            if (derivedShip.ShipDeflector.Serviceability)
            {
                derivedShip.ShipDeflector.SetHealthOfDeflector(derivedShip.ShipDeflector.HealthOfDeflector -
                                                               StandardDamage);
                return;
            }

            derivedShip.ShipHull.SetHealthOfHull(derivedShip.ShipHull.HealthOfHull - StandardDamage);
            derivedShip.CheckShipAlive();
            return;
        }

        ship.ShipHull.SetHealthOfHull(ship.ShipHull.HealthOfHull - StandardDamage);
        ship.CheckShipAlive();
    }
}