namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces;

public interface ICanBeLaunched : IOperationalStatus
{
    bool Running { get; set; }
}