using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;

public interface IServices ////Methods are needed in this interface so that they are not static.
{
    WhatHappenedStatus CheckWhatHappened(ShipBase ship);

    int GetOptimumShip(IEnumerable<ShipBase> survivorsShips, IEnumerable<ShipBase> allShips, ICollection<SpaceBase> manySegments);
    Collection<bool> TryLaunchShips(IEnumerable<ShipBase> manyShips, ICollection<SpaceBase> manySegments);
}