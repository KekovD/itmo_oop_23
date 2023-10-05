﻿using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.PartEntities.TankEntities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.TankSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

public abstract class BaseShip : IShipHull, IShipImpulseEngine, IShipAntiNitrinoEmitter, IShipWeight, IShipCrew, ICheckShipAlive,
    IGetImpulseFuelCost
{
    protected const double ShipWeightRatio = 0.05;
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

    public int ShipImpulseFuelCost(int distance)
    {
        if (ImpulseEngine == null)
        {
            throw new PartOfShipNullException(nameof(ImpulseEngine));
        }

        int speed = ImpulseEngine.GetImpulseEngineSpeed(distance) - (int)(ShipWeightRatio * ShipWeight);
        int time = (int)(speed / distance);

        return ((time * ImpulseEngine.FuelUsePerUnitTime) + ImpulseEngine.FuelUseAtStartup) * (int)PriceOfFuel.PriceStandardFuel;
    }
}