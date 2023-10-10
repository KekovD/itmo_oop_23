namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

public abstract class BaseObstacles
{
    protected const int AntimatterFlashesDamage = 1;
    protected const int SmallAsteroidsDamage = 10;
    protected const int MeteoritesDamage = 40;
    protected const int SpaceWhalesDamage = 1000;
    public int Damage { get; protected init; }
}