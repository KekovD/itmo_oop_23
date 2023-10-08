using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.TankSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

public abstract class BaseShipWithJumpEngineAndDeflector : BaseShipWithDeflector, IBaseShipWithJumpEngineAndDeflectorInterface
{
    public BaseJumpEngines? JumpEngine { get; protected init; }
    public bool EnoughDistanceJump { get; private set; } = true;

    public void SetFalseEnoughDistanceJump()
    {
        EnoughDistanceJump = false;
    }

    public int JumpFuelPrice(int distance)
    {
        if (JumpEngine == null)
        {
            throw new PartOfShipNullException(nameof(ImpulseEngine));
        }

        return JumpEngine.GetEngineFuelConsumption(distance, Weight) * (int)PriceOfFuel.PriceStandardFuel;
    }
}