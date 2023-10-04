using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.TypeOfShip;

public interface IGetBaseTypeOfShip
{
    static abstract Type? GetBaseTypeOfShip(BaseShip ship);
}