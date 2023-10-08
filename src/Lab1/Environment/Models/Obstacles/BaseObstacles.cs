using Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.BaseInterfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

public abstract class BaseObstacles : IObstacles
{
    protected const int AntimatterFlashesDamage = 1;
    protected const int SmallAsteroidsDamage = 10;
    protected const int MeteoritesDamage = 40;
    protected const int SpaceWhalesDamage = 1000;
    public int Damage { get; protected init; }
    public abstract void DoingDamage(BaseShip ship);
}