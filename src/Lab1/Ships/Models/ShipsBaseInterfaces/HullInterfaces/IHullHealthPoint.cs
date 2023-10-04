namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.HullInterfaces;

public interface IHullHealthPoint : IOperationalStatus, ISetHealthOfHull
{
    int HealthOfHull { get; }
}