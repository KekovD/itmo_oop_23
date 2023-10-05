using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces.ObstaclesBaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.ShipsModels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.ObstaclesModels;

public abstract class BaseStandardObstacles : IDoingDamage, IMyStandardDamage
{
    public int StandardDamage { get; protected init; }
    public abstract void DoingDamage(BaseShip ship);
}