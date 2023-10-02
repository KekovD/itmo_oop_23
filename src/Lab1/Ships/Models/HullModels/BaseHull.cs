using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.HullInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;

public abstract class BaseHull : IHullHealthPoint
{
    public int HealthOfHull { get; protected set; }
}