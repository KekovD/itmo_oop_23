using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

public abstract class BaseSpaceWhales : BaseObstacles
{
    public override void DoingDamage(BaseShip ship)
    {
        if (ship.AntiNitrinoEmitter)
        {
            return;
        }

        if (ship is BaseShipWithDeflector derivedShip)
        {
            if (derivedShip.Deflector.Serviceability)
            {
                derivedShip.Deflector.SetHealthOfDeflector(derivedShip.Deflector.HealthOfDeflector -
                                                               StandardDamage);
                derivedShip.Deflector.SetPartServiceability();
                return;
            }
        }

        if (ship.Hull == null)
        {
            throw new PartOfShipNullException(nameof(ship.Hull));
        }

        ship.Hull.SetHealthOfHull(ship.Hull.HealthOfHull - StandardDamage);
        ship.CheckShipAlive();
    }
}