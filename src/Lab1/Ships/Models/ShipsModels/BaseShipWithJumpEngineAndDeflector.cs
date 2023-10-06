using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

public abstract class BaseShipWithJumpEngineAndDeflector : BaseShipWithDeflector, IShipJumpEngine, IShipIJumpFuelCost, ISetEnoughDistanceJump
{
    public BaseJumpEngines? JumpEngine { get; protected init; }
    public JumpTank? ShipJumpTank { get; protected init; }
    public bool EnoughDistanceJump { get; private set; } = true;
    public abstract int ShipIJumpFuelCost(int distance);
    public abstract int ShipJumpFuelConsumption(int distance);

    public void SetFalseEnoughDistanceJump()
    {
        EnoughDistanceJump = false;
    }
}