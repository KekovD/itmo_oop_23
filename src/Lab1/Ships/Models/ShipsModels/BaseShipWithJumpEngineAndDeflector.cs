using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

public abstract class BaseShipWithJumpEngineAndDeflector : BaseShipWithDeflector, IShipJumpEngine
{
    protected BaseShipWithJumpEngineAndDeflector(int currentMoney)
        : base(currentMoney)
    {
    }

    public BaseJumpEngines JumpEngine { get; protected init; } = new BaseJumpEngines();
    public JumpTank ShipJumpTank { get; protected init; } = new JumpTank();
}