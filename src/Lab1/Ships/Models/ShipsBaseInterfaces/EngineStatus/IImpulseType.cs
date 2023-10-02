using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.StandardSpecifications.EngineSpecifications;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsBaseInterfaces.EngineStatus;

public interface IImpulseType
{
    ImpulseEngineType ImpulseType { get; }
}