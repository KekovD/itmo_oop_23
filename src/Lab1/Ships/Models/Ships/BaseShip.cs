using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities.Other;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.LabException;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.AdditionalEquipment;
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
            throw new PartOfShipNullException(nameof(ImpulseEngine));

        return ImpulseEngine.GetEngineFuelConsumption(distance, Weight) * fuelExchange.ImpulseFuelPrice();
    }

    public virtual bool TryOvercomeJumpDistance(int distance)
    {
        return false;
    }

    public virtual void TakingDamage(BaseObstacles obstacles)
    {
        if (obstacles is IHighDensitySpaceNebulae)
            KillCrew();

        if (obstacles is INitrinoParticleNebulae)
        {
            if (CheckAntiNitrinoEmitter())
                return;
        }

        if (Hull == null)
            throw new PartOfShipNullException(nameof(Hull));

        Hull.DamagingPart(obstacles.Damage);
        CheckShipAlive();
    }

    public int CostOfRoute(BaseSpace space, int distance, FuelExchange fuelExchange)
    {
        const int wrongTypeOfEngineRatio = 100000;
        if (space is INormalSpace)
            return ImpulseFuelPrice(distance, fuelExchange);

        if (space is INitrinoParticleNebulae && ImpulseEngine is INitrinoParticleNebulae)
            return ImpulseFuelPrice(distance, fuelExchange);

        return ImpulseFuelPrice(distance, fuelExchange) * wrongTypeOfEngineRatio;
    }

    protected bool CheckAntiNitrinoEmitter()
    {
        return AdditionalEquipment.Any(equipment => equipment is AntiNitrinoEmitter);
    }
}