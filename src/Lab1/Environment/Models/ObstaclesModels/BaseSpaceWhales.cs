using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

public abstract class BaseSpaceWhales : BaseObstacles
{
    public override void DoingDamage(BaseShip ship)
    {
        if (ship.ShipAntiNitrinoEmitter)
        {
            return;
        }

        if (ship is BaseShipWithDeflector derivedShip)
        {
            if (derivedShip.ShipDeflector.Serviceability)
            {
                derivedShip.ShipDeflector.SetHealthOfDeflector(derivedShip.ShipDeflector.HealthOfDeflector -
                                                               StandardDamage);
                derivedShip.ShipDeflector.SetPartServiceability();
                return;
            }
        }

        if (ship.ShipHull == null)
        {
            throw new PartOfShipNullException(nameof(ship.ShipHull));
        }

        ship.ShipHull.SetHealthOfHull(ship.ShipHull.HealthOfHull - StandardDamage);
        ship.CheckShipAlive();
    }
}