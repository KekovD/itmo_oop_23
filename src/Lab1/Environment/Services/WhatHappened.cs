using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Services;

public abstract class WhatHappened : OptimumShip, ICheckWhatHappened
{
    public WhatHappenedStatus CheckWhatHappened(BaseShip ship)
    {
        if (!ship.ShipCrewAlive)
        {
            return WhatHappenedStatus.CrewKilled;
        }

        if (!ship.ShipHull.Serviceability)
        {
            return WhatHappenedStatus.ShipDestroyed;
        }

        if (ship is BaseShipWithJumpEngineAndDeflector { EnoughDistanceJump: false })
        {
            return WhatHappenedStatus.ShortJumpRange;
        }

        if (ship is BaseShipWithDeflector { ShipDeflector.Serviceability: false })
        {
            return WhatHappenedStatus.DeflectorDestroyed;
        }

        if (ship.NoJumpEngineCheck == false)
        {
            return WhatHappenedStatus.NoJumpEngine;
        }

        return WhatHappenedStatus.Successfully;
    }

    public abstract string GetWhatHappenedName(WhatHappenedStatus value);
}