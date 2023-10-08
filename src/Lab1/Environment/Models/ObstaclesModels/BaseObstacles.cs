using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

public abstract class BaseObstacles : IObstaclesInterfaces
{
    public int StandardDamage { get; protected init; }
    public abstract void DoingDamage(BaseShip ship);
}