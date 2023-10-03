using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.HullInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.HullSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.HullModels;

public class BaseHull : IHullHealthPoint, IPartWeight
{
    public int HealthOfHull { get; protected set; } = (int)HealthPointHull.HullBrokenHealth;
    public bool Serviceability { get; protected set; } = true;
    public int PartWeight { get; protected init; }
}