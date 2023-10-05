namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.HullInterfaces;

public interface IHullHealthPoint : ISetHealthOfHull
{
    int HealthOfHull { get; }
}