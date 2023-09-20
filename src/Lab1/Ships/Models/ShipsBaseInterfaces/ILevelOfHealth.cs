namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces;

public interface ILevelOfHealth : IOperationalStatus
{
    int Health { get; set; }
}