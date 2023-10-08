using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

public abstract class BaseAntimatterFlashes : BaseObstacles
{
    public override void DoingDamage(BaseShip ship)
    {
        if (ship is BaseShipWithDeflector { Deflector.DeflectAntimatterFlares: true } derivedShip)
        {
            derivedShip.Deflector.SetHealthOfPhotonsDeflector(derivedShip.Deflector.PhotonsHealth -
                                                                  StandardDamage);
            return;
        }

        ship.KillCrew();
    }
}