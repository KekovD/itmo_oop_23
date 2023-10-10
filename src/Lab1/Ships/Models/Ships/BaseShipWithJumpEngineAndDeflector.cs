using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Other;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

public abstract class BaseShipWithJumpEngineAndDeflector : BaseShipWithDeflector
{
    public BaseJumpEngines? JumpEngine { get; protected init; }
    public bool EnoughDistanceJumpStatus { get; private set; } = true;

    public void SetFalseEnoughDistanceJump()
    {
        EnoughDistanceJumpStatus = false;
    }

    public int JumpFuelPrice(int distance, FuelExchange fuelExchange)
    {
        if (JumpEngine == null)
        {
            throw new PartOfShipNullException(nameof(ImpulseEngine));
        }

        return JumpEngine.GetEngineFuelConsumption(distance, Weight) * fuelExchange.ImpulseFuelPrice();
    }

    public override bool TryOvercomeJumpDistance(int distance)
    {
        if (JumpEngine == null)
        {
            throw new PartOfShipNullException(nameof(JumpEngine));
        }

        if (JumpEngine.Rage < distance)
        {
            SetFalseEnoughDistanceJump();
            return false;
        }

        return true;
    }
}