using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.DeflectorsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.BaseInterfaces.Ship;

public interface IBaseShipWithDeflector
{
    BaseDeflector Deflector { get; }
}