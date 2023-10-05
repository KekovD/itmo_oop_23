using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.SpaceEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class TrySingleTraverseRouteDistance : ITryTraverseRouteDistance
{
    public bool TryTraverseRouteDistance(BaseShip ship, BaseSpace space, int distance)
    {
        if (space is NormalSpace)
        {
            if (ship.ShipStandardTank == null)
            {
                throw new PartOfShipNullException(nameof(ship.ShipStandardTank));
            }

            if (ship.ShipImpulseFuelConsumption(distance) > ship.ShipStandardTank.FuelResidue)
            {
                return false;
            }

            return true;
        }

        if (space is HighDensitySpaceNebulae)
        {
            if (ship is BaseShipWithJumpEngineAndDeflector derivedShip)
            {
                if (derivedShip.ShipJumpFuelConsumption(distance) > derivedShip.ShipJumpTank.FuelResidue)
                {
                    return false;
                }

                if (derivedShip.JumpEngine == null)
                {
                    throw new PartOfShipNullException(nameof(derivedShip.JumpEngine));
                }

                if (derivedShip.JumpEngine.JumpRage < distance)
                {
                    return false;
                }

                return true;
            }

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

        return false;
    }
}