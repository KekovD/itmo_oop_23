using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

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

            if (derivedShip.Deflector == null)
            {
                throw new PartOfShipNullException(nameof(derivedShip.Deflector));
            }

            if (derivedShip.Deflector.Serviceability)
            {
                derivedShip.Deflector.DamagingPart(Damage);
                return;
            }

            derivedShip.Hull.DamagingPart(Damage);
            derivedShip.CheckShipAlive();
            return;
        }

        ship.Hull.DamagingPart(Damage);
        ship.CheckShipAlive();
    }
}