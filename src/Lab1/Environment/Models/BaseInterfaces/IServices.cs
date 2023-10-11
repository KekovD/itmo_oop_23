using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.StandardSpecifications;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;

/// <summary>
/// Methods are needed in this interface so that they are not static.
/// </summary>
public interface IServices
{
    WhatHappenedStatus CheckWhatHappened(ShipBase ship);
    int GetOptimumShip(IEnumerable<ShipBase> survivorsShips, IEnumerable<ShipBase> allShips, ICollection<SpaceBase> manySegments);
    IEnumerable<bool> TryLaunchShips(IEnumerable<ShipBase> manyShips, ICollection<SpaceBase> manySegments);
}