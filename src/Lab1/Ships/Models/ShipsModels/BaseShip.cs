using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

public abstract class BaseShip : IShipHull, IShipImpulseEngine, IShipAntiNitrinoEmitter, IShipWeight, IShipCrew, ICheckShipAlive
{
    public bool ShipAlive { get; private set; } = true;
    public bool ShipCrewAlive { get; private set; } = true;
    public BaseImpulseEngines ImpulseEngine { get; protected init; } = new BaseImpulseEngines();
    public BaseHull ShipHull { get; protected init; } = new BaseHull();
    public StandardTank ShipStandardTank { get; protected init; } = new StandardTank();
    public bool ShipAntiNitrinoEmitter { get; protected init; }
    public int ShipWeight { get; protected set; }

    public void SetShipAlive()
    {
        ShipAlive = ShipHull.Serviceability & ShipCrewAlive;
    }

    public void KillCrew()
    {
        ShipCrewAlive = false;
        SetShipAlive();
    }
}