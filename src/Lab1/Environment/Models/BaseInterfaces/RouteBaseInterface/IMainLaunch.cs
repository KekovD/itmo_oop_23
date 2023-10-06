using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.EnvironmentsOfSpaceModels;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.RouteBaseInterface;

public interface IMainLaunch
{
    IList<IList<string>> MainLaunch(IList<BaseShip> manyShips, IList<BaseSpace> manySpaces);
}