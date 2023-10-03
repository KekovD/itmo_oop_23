using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

public abstract class BaseShipWithJumpEngineAndDeflector : BaseShip, IShipJumpEngine, IShipDeflector
{
    protected BaseShipWithJumpEngineAndDeflector(int currentMoney)
        : base(currentMoney)
    {
    }

    public BaseJumpEngines JumpEngine { get; protected init; } = new BaseJumpEngines();
    public JumpTank ShipJumpTank { get; protected init; } = new JumpTank();
    public BaseDeflector ShipDeflector { get; protected init; } = new BaseDeflector();
}