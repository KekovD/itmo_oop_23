using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

public abstract class BaseAntimatterFlashes : BaseSmallAsteroidsAndMeteorites
{
    public override void DoingDamage(BaseShip ship)
    {
        if (ship is BaseShipWithDeflector { ShipDeflector.DeflectAntimatterFlares: true } derivedShip)
        {
            derivedShip.ShipDeflector.SetHealthOfPhotonsDeflector(derivedShip.ShipDeflector.PhotonsHealth -
                                                                  StandardDamage);
            return;
        }

        ship.KillCrew();
    }
}