using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Other;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

public abstract class BaseShipWithJumpEngineAndDeflector : BaseShipWithDeflector, IBaseShipWithJumpEngineAndDeflector
{
    public BaseJumpEngines? JumpEngine { get; protected init; }
    public bool EnoughDistanceJumpStatus { get; private set; } = true;

    public void SetFalseEnoughDistanceJump()
    {
        EnoughDistanceJumpStatus = false;
    }

    public int JumpFuelPrice(int distance)
    {
        if (JumpEngine == null)
        {
            throw new PartOfShipNullException(nameof(ImpulseEngine));
        }

        return JumpEngine.GetEngineFuelConsumption(distance, Weight) * new FuelExchange().JumpFuelPrice();
    }
}