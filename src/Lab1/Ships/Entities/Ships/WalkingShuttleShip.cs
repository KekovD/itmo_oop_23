using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Ships;

public class WalkingShuttleShip : BaseShip, INormalSpace
{
    public WalkingShuttleShip()
    {
        Hull = new HullFirst();
        ImpulseEngine = new CImpulseEngine();
        Weight = Hull.PartWeight + ImpulseEngine.PartWeight;
    }
}