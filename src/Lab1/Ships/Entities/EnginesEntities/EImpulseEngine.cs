using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.EnginesModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.EnginesEntities;

public class EImpulseEngine : BaseEngines, IExponentialAcceleration
{
    public EImpulseEngine(int grade)
        : base(grade)
    {
        TypeOfEngine = BaseEngineType.StandardEngine;
        FuelUseAtStartup = (int)StandardEngineCharacteristics.EEngineConstantFuelFlow;
        FuelUsePerUnitTime = (int)StandardEngineCharacteristics.EEngineConstantFuelFlow; ////TODO: rework
    }

    public int ExponentialAcceleration(int speed, int distance) ////TODO: maybe refactor
    {
        int time = 0;
        int currentDistance = 0;
        const int dt = 2;

        while (currentDistance < distance)
        {
            time++;
            int vt = ((5 * time) + 1) * speed;
            currentDistance += vt * dt;
        }

        return time;
    }
}