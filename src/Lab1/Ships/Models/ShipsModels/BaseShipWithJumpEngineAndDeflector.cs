using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

public abstract class BaseShipWithJumpEngineAndDeflector : BaseShipWithDeflector, IBaseShipWithJumpEngineAndDeflectorInterface
{
    public BaseJumpEngines? JumpEngine { get; protected init; }
    public bool EnoughDistanceJump { get; private set; } = true;
    public abstract int JumpFuelCost(int distance);
    public abstract int JumpFuelConsumption(int distance);

    public void SetFalseEnoughDistanceJump()
    {
        EnoughDistanceJump = false;
    }
}