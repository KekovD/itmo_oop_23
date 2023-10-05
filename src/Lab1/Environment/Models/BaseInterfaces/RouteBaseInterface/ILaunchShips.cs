using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;

public interface ILaunchShips
{
     ICollection<ICollection<bool>> LaunchShips(ICollection<BaseShip> manyShips, ICollection<BaseSpace> manySegment);
}