using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Other;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

public abstract class ShipWithJumpEngineAndDeflectorBase : ShipWithDeflectorBase
{
    public EnginesBaseJump? JumpEngine { get; protected init; }
    public bool EnoughDistanceJumpStatus { get; private set; } = true;

    public override bool TryOvercomeJumpDistance(int distance)
    {
        if (JumpEngine is null)
            throw new PartOfShipNullException(nameof(JumpEngine));

        if (JumpEngine.Rage < distance)
        {
            SetFalseEnoughDistanceJump();
            return false;
        }

        return true;
    }

    public new int CostOfRoute(SpaceBase space, int distance, FuelExchange fuelExchange)
    {
        return space is HighDensityNebulaeSpace
            ? JumpFuelPrice(distance, fuelExchange)
            : base.CostOfRoute(space, distance, fuelExchange);
    }

    private int JumpFuelPrice(int distance, FuelExchange fuelExchange)
    {
        if (JumpEngine is null)
            throw new PartOfShipNullException(nameof(ImpulseEngine));

        return JumpEngine.GetEngineFuelConsumption(distance, Weight) * fuelExchange.ImpulseFuelPrice;
    }

    private void SetFalseEnoughDistanceJump()
    {
        EnoughDistanceJumpStatus = false;
    }
}