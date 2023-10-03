using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.TankModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

public abstract class BaseShip : IHaveJumpEngine, IHaveDeflector, IShipHull, IShipImpulseEngine
{
    public bool HaveJumpEngine { get; protected init; }
    public bool HaveDeflector { get; protected init; }
    public BaseImpulseEngines ImpulseEngine { get; protected init; } = new BaseImpulseEngines();
    public BaseHull ShipHull { get; protected init; } = new BaseHull();
    public BaseTank ShipStandardTank { get; protected init; } = new BaseTank();
}