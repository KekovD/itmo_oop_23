﻿using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Other;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

public abstract class BaseShip : IBaseShip
{
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

        return ImpulseEngine.GetEngineFuelConsumption(distance, Weight) * new FuelExchange().ImpulseFuelPrice();
    }
}