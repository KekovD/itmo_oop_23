namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.ShipInterfaces;

public interface INoJumpEngine : ISetNoJumpEngine
{
    bool NoJumpEngineCheck { get; }
}