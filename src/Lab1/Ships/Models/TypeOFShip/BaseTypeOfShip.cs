using System;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.TypeOfShip;

public abstract class BaseTypeOfShip : IGetBaseTypeOfShip
{
    public static Type? GetBaseTypeOfShip(BaseShip ship)
    {
        Type type = ship.GetType();
        Type? baseType = type.BaseType;
        return baseType;
    }
}