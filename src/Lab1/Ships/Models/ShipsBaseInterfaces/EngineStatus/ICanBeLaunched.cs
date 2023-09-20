namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;

public interface ICanBeLaunched : IOperationalStatus
{
    bool Running { get; set; }
}