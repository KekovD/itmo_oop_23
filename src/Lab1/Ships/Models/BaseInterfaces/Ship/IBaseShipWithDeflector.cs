using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Ship;

public interface IBaseShipWithDeflector
{
    BaseDeflector? Deflector { get; }
}