using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

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
            if (derivedShip.Deflector == null)
            {
                throw new PartOfShipNullException(nameof(derivedShip.Deflector));
            }

            if (derivedShip.Deflector.Serviceability)
            {
                derivedShip.Deflector.DamagingPart(Damage);
                derivedShip.Deflector.SetPartServiceability();
                return;
            }
        }

        if (ship.Hull == null)
        {
            throw new PartOfShipNullException(nameof(ship.Hull));
        }

        ship.Hull.DamagingPart(Damage);
        ship.CheckShipAlive();
    }
}