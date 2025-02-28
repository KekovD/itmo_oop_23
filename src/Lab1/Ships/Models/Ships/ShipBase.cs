﻿using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Other;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.AdditionalEquipment;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

public abstract class ShipBase
{
    public bool ShipAlive { get; private set; } = true;
    public bool CrewAlive { get; private set; } = true;
    public EnginesImpulseBase? ImpulseEngine { get; protected init; }
    public HullBase? Hull { get; protected init; }
    public bool NoJumpEngineStatus { get; private set; } = true;
    protected int Weight { get; init; }
    protected IEnumerable<IAdditionalEquipment> AdditionalEquipment { get; init; } = new List<IAdditionalEquipment>();

    public void SetFalseNoJumpStatus()
    {
        NoJumpEngineStatus = false;
    }

    public virtual bool TryOvercomeJumpDistance(int distance)
    {
        return false;
    }

    public virtual void TakingDamage(ObstaclesBase obstacles)
    {
        if (obstacles is AntimatterFlash)
            KillCrew();

        if (obstacles is SpaceWhales)
        {
            if (CheckAvailabilityAdditionalEquipment(new AntiNitrinoEmitter()))
                return;
        }

        if (Hull is null)
            throw new PartOfShipNullException(nameof(Hull));

        Hull.DamagingPart(obstacles.Damage);
        CheckShipAlive();
    }

    public int CostOfRoute(SpaceBase space, int distance, FuelExchange fuelExchange)
    {
        const int wrongTypeOfEngineRatio = 100000;

        if (space is NormalSpace)
            return ImpulseFuelPrice(distance, fuelExchange);

        if (space is NitrinoParticleNebulaeSpace && ImpulseEngine is EnginesImpulseBase)
            return ImpulseFuelPrice(distance, fuelExchange);

        return ImpulseFuelPrice(distance, fuelExchange) * wrongTypeOfEngineRatio;
    }

    protected void CheckShipAlive()
    {
        if (Hull is null)
            throw new PartOfShipNullException(nameof(Hull));

        ShipAlive = Hull.Serviceability & CrewAlive;
    }

    protected void KillCrew()
    {
        CrewAlive = false;
        CheckShipAlive();
    }

    protected bool CheckAvailabilityAdditionalEquipment(IAdditionalEquipment additionalEquipment)
    {
        return AdditionalEquipment.Contains(additionalEquipment);
    }

    private int ImpulseFuelPrice(int distance, FuelExchange fuelExchange)
    {
        if (ImpulseEngine is null)
            throw new PartOfShipNullException(nameof(ImpulseEngine));

        return ImpulseEngine.GetEngineFuelConsumption(distance, Weight) * fuelExchange.ImpulseFuelPrice;
    }
}