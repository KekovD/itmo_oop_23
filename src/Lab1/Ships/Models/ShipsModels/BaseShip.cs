using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

public abstract class BaseShip : IShipHull, IShipImpulseEngine, IShipMoney, IShipAntiNitrinoEmitter, IShipWeight, IShipCrew
{
    protected BaseShip(int currentMoney)
    {
        ShipMoney = currentMoney;
    }

    public bool ShipCrewAlive { get; protected set; } = true;
    public int ShipMoney { get; protected set; }
    public BaseImpulseEngines ImpulseEngine { get; protected init; } = new BaseImpulseEngines();
    public BaseHull ShipHull { get; protected init; } = new BaseHull();
    public StandardTank ShipStandardTank { get; protected init; } = new StandardTank();
    public bool ShipAntiNitrinoEmitter { get; protected init; }
    public int ShipWeight { get; protected set; }
}