namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.HullInterfaces;

public interface IHullHealthPoint : IOperationalStatus
{
    int HealthOfHull { get; }
}