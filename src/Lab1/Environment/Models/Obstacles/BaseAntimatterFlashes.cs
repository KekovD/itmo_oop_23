using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

public abstract class BaseAntimatterFlashes : BaseObstacles
{
    public override void DoingDamage(BaseShip ship)
    {
        if (ship is BaseShipWithDeflector { Deflector.DeflectAntimatterFlares: true } derivedShip)
        {
            derivedShip.Deflector.DamagingPhotonsDeflector(Damage);
            return;
        }

        ship.KillCrew();
    }
}