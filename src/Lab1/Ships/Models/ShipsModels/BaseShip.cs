using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

public abstract class BaseShip : IShipHull, IShipImpulseEngine, IShipAntiNitrinoEmitter, IShipWeight, IShipCrew, ICheckShipAlive, IShipImpulseSpeed
{
    private const double ShipWeightRatio = 0.01;
    public bool ShipAlive { get; private set; } = true;
    public bool ShipCrewAlive { get; private set; } = true;
    public BaseImpulseEngines? ImpulseEngine { get; protected init; }
    public BaseHull ShipHull { get; protected init; } = new BaseHull();
    public StandardTank? ShipStandardTank { get; protected init; }
    public bool ShipAntiNitrinoEmitter { get; protected init; }
    public int ShipWeight { get; protected init; }

    public void SetShipAlive()
    {
        ShipAlive = ShipHull.Serviceability & ShipCrewAlive;
    }

    public void KillCrew()
    {
        ShipCrewAlive = false;
        SetShipAlive();
    }

    public int ShipImpulseSpeed(int distance)
    {
        if (ImpulseEngine == null)
        {
            throw new PartOfShipNullException(nameof(ImpulseEngine));
        }

        return ImpulseEngine.GetImpulseEngineSpeed(distance) - (int)(ShipWeightRatio * ShipWeight);
    }
}