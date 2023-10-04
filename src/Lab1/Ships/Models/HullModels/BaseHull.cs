using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.HullInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;

public class BaseHull : IHullHealthPoint, IPartWeight
{
    public int HealthOfHull { get; protected set; }
    public bool Serviceability { get; protected set; } = true;
    public int PartWeight { get; protected init; }
}