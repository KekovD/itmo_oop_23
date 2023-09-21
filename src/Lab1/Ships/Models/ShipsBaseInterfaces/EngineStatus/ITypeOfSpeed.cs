namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;

public interface ITypeOfSpeed : IGradationPart, IEngineTypeIdentification
{
    BaseEngineType TypeOfEngine { get; }
}