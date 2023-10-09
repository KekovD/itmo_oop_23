using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
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

    public int JumpFuelPrice(int distance, IFuelExchange fuelExchange)
    {
        if (JumpEngine == null)
        {
            throw new PartOfShipNullException(nameof(ImpulseEngine));
        }

        return JumpEngine.GetEngineFuelConsumption(distance, Weight) * fuelExchange.ImpulseFuelPrice();
    }
}