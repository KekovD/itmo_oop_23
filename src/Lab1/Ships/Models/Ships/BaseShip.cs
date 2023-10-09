using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Other;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

public abstract class BaseShip
{
    public bool ShipAlive { get; private set; } = true;
    public bool CrewAlive { get; private set; } = true;
    public BaseImpulseEngines? ImpulseEngine { get; protected init; }
    public BaseHull? Hull { get; protected init; }
    public int Weight { get; protected init; }
    public bool NoJumpEngineStatus { get; private set; } = true;
    public IEnumerable<IAdditionalEquipment> AdditionalEquipment { get; protected init; } = new List<IAdditionalEquipment>();

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

    public int ImpulseFuelPrice(int distance, FuelExchange fuelExchange)
    {
        if (ImpulseEngine == null)
        {
            throw new PartOfShipNullException(nameof(ImpulseEngine));
        }

        return ImpulseEngine.GetEngineFuelConsumption(distance, Weight) * fuelExchange.ImpulseFuelPrice();
    }
}