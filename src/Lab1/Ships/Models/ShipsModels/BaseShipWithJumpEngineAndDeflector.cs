using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.TankSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

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

        return JumpEngine.GetEngineFuelConsumption(distance, Weight) * (int)PriceOfFuel.PriceJumpFuel;
    }
}