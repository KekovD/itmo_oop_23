using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.TankSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

public abstract class BaseShip : IBaseShipInterface
{
    protected const double WeightRatio = 0.05;
    public bool ShipAlive { get; private set; } = true;
    public bool CrewAlive { get; private set; } = true;
    public BaseImpulseEngines? ImpulseEngine { get; protected init; }
    public BaseHull? Hull { get; protected init; }
    public bool AntiNitrinoEmitter { get; protected init; }
    public int Weight { get; protected init; }
    public bool NoJumpEngineStatus { get; private set; } = true;

    public void CheckShipAlive()
    {
        if (Hull == null)
        {
            throw new PartOfShipNullException(nameof(Hull));
        }

        ShipAlive = Hull.Serviceability & CrewAlive;
    }

    public void KillCrew()
    {
        CrewAlive = false;
        CheckShipAlive();
    }

    public void SetFalseNoJumpStatus()
    {
        NoJumpEngineStatus = false;
    }

    public int ImpulseFuelPrice(int distance)
    {
        if (ImpulseEngine == null)
        {
            throw new PartOfShipNullException(nameof(ImpulseEngine));
        }

        return ImpulseEngine.GetEngineFuelConsumption(distance, Weight) * (int)PriceOfFuel.PriceStandardFuel;
    }
}