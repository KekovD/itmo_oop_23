namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.HullInterfaces;

public interface IHullHealthPoint : IGradationPart
{
    int HealthOfHull { get; }
}