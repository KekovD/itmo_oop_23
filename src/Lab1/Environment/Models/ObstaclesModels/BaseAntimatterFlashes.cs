using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

public abstract class BaseAntimatterFlashes : BaseObstacles
{
    public override void DoingDamage(BaseShip ship)
    {
        if (ship is BaseShipWithDeflector { Deflector.DeflectAntimatterFlares: true } derivedShip)
        {
            derivedShip.Deflector.DamagingPhotonsDeflector(StandardDamage);
            return;
        }

        ship.KillCrew();
    }
}