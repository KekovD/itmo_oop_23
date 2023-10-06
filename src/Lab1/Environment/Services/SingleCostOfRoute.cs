using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.SpaceEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.EnginesEntities.ImpulseEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public abstract class SingleCostOfRoute : ISingleCostOfRoute
{
    private const int WrongTypeOfEngineRatio = 100000;
    public int GetSingleCostOfRoute(BaseShip ship, BaseSpace space, int distance)
    {
        if (space is NormalSpace)
        {
            return ship.ShipImpulseFuelCost(distance);
        }

        if (space is HighDensitySpaceNebulae)
        {
            if (ship is BaseShipWithJumpEngineAndDeflector derivedShip)
            {
                return derivedShip.ShipIJumpFuelCost(distance);
            }

            return ship.ShipImpulseFuelCost(distance) * WrongTypeOfEngineRatio;
        }

        if (space is NitrinoParticleNebulae)
        {
            if (ship.ImpulseEngine is CImpulseEngine)
            {
                return ship.ShipImpulseFuelCost(distance) * WrongTypeOfEngineRatio;
            }

            return ship.ShipImpulseFuelCost(distance);
        }

        throw new ServicesInvalidOperationException(nameof(GetSingleCostOfRoute));
    }
}