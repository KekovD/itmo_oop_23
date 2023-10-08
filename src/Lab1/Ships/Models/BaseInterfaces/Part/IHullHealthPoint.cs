namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Part;

public interface IHullHealthPoint
{
    int HealthOfHull { get; }
    void DamagingHull(int damage);
}