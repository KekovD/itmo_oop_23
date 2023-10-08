namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.PartInterfaces;

public interface IHullHealthPoint
{
    int HealthOfHull { get; }
    void DamagingHull(int damage);
}