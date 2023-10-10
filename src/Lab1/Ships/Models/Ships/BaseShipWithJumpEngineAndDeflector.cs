using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Other;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

public abstract class BaseShipWithJumpEngineAndDeflector : BaseShipWithDeflector
{
    public BaseJumpEngines? JumpEngine { get; protected init; }
    public bool EnoughDistanceJumpStatus { get; private set; } = true;

    public override bool TryOvercomeJumpDistance(int distance)
    {
        if (JumpEngine == null)
            throw new PartOfShipNullException(nameof(JumpEngine));

        if (JumpEngine.Rage < distance)
        {
            SetFalseEnoughDistanceJump();
            return false;
        }

        return true;
    }

    public new int CostOfRoute(BaseSpace space, int distance, FuelExchange fuelExchange)
    {
        if (space is IHighDensitySpaceNebulae)
            return JumpFuelPrice(distance, fuelExchange);

        return base.CostOfRoute(space, distance, fuelExchange);
    }

    private int JumpFuelPrice(int distance, FuelExchange fuelExchange)
    {
        if (JumpEngine == null)
            throw new PartOfShipNullException(nameof(ImpulseEngine));

        return JumpEngine.GetEngineFuelConsumption(distance, Weight) * fuelExchange.ImpulseFuelPrice;
    }

    private void SetFalseEnoughDistanceJump()
    {
        EnoughDistanceJumpStatus = false;
    }
}