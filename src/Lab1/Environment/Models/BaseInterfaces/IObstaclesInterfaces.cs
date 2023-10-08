using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;

public interface IObstaclesInterfaces
{
    int StandardDamage { get; }
    void DoingDamage(BaseShip ship);
}