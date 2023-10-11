using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Part.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities.Ships;

public class WalkingShuttle : ShipBase
{
    public WalkingShuttle()
    {
        Hull = new FirstHull();
        ImpulseEngine = new CImpulse();
        Weight = Hull.PartWeight + ImpulseEngine.PartWeight;
    }
}