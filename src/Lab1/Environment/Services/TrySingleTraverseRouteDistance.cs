using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.SpaceEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public abstract class TrySingleTraverseRouteDistance : TrySingleTraverseRouteDamage, ITryTraverseRouteDistance
{
    public bool TryTraverseRouteDistance(BaseShip ship, BaseSpace space, int distance)
    {
        if (space is NormalSpace)
        {
            if (ship.ShipStandardTank == null)
            {
                throw new PartOfShipNullException(nameof(ship.ShipStandardTank));
            }

            return true;
        }

        if (space is HighDensitySpaceNebulae)
        {
            if (ship is BaseShipWithJumpEngineAndDeflector derivedShip)
            {
                if (derivedShip.JumpEngine == null)
                {
                    throw new PartOfShipNullException(nameof(derivedShip.JumpEngine));
                }

                if (derivedShip.JumpEngine.JumpRage < distance)
                {
                    derivedShip.SetFalseEnoughDistanceJump();
                    return false;
                }

                return true;
            }

            ship.SetNoJumpStatus();
            return false;
        }

        if (space is NitrinoParticleNebulae)
        {
            if (ship.ImpulseEngine is CImpulseEngine)
            {
                return false;
            }

            return true;
        }

        throw new ServicesInvalidOperationException(nameof(TryTraverseRouteDistance));
    }
}