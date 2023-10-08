using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;

public interface IObstaclesInterfaces
{
    int StandardDamage { get; }
    void DoingDamage(BaseShip ship);
}