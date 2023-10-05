using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.SpaceEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public class TrySingleTraverseRoute : ITryTraverseRoute
{
    public bool TryTraverseRoute(BaseShip ship, BaseSpace space, int distance)
    {
        if (space is NormalSpace derivedSpace)
        {
            if (ship.ShipStandardTank == null)
            {
                throw new PartOfShipNullException(nameof(ship.ShipStandardTank));
            }

            if (ship.ShipImpulseFuelConsumption(distance) > ship.ShipStandardTank.FuelResidue)
            {
                return false;
            }

            if (derivedSpace.TypeOfObstacles == null)
            {
                throw new PartOfSpaceNullException(nameof(derivedSpace.TypeOfObstacles));
            }

            if (derivedSpace.TypeOfSecondObstacles == null)
            {
                throw new PartOfSpaceNullException(nameof(derivedSpace.TypeOfSecondObstacles));
            }

            for (int i = 1; i < derivedSpace.NumberOfObstaclesOnRoute; i++)
            {
                derivedSpace.TypeOfObstacles.DoingDamage(ship);
            }

            for (int i = 1; i < derivedSpace.SecondNumberOfObstaclesOnRoute; i++)
            {
                derivedSpace.TypeOfSecondObstacles.DoingDamage(ship);
            }

            if (ship.ShipAlive == false)
            {
                return false;
            }

            return true;
        }

        if (space is HighDensitySpaceNebulae derivedSpaceSecond)
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

                if (derivedSpaceSecond.TypeOfObstacles == null)
                {
                    throw new PartOfSpaceNullException(nameof(derivedSpaceSecond.TypeOfObstacles));
                }

                for (int i = 1; i < derivedSpaceSecond.NumberOfObstaclesOnRoute; i++)
                {
                    derivedSpaceSecond.TypeOfObstacles.DoingDamage(derivedShip);
                }

                if (derivedShip.ShipAlive == false)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        if (space is NitrinoParticleNebulae derivedSpaceThird)
        {
            if (ship.ShipAntiNitrinoEmitter == false && derivedSpaceThird.NumberOfObstaclesOnRoute != 0)
            {
                if (derivedSpaceThird.TypeOfObstacles == null)
                {
                    throw new PartOfSpaceNullException(nameof(derivedSpaceThird.TypeOfObstacles));
                }

                for (int i = 1; i < derivedSpaceThird.NumberOfObstaclesOnRoute; i++)
                {
                    derivedSpaceThird.TypeOfObstacles.DoingDamage(ship);
                }

                return false;
            }

            if (ship.ImpulseEngine is CImpulseEngine)
            {
                return false;
            }

            return true;
        }

        return false;
    }
}