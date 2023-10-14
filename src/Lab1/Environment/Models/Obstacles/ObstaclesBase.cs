namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models.Obstacles;

public abstract class ObstaclesBase
{
    protected ObstaclesBase(int obstaclesCounter)
    {
        ObstaclesCounter = obstaclesCounter;
    }

    public int Damage { get; protected init; }
    public int ObstaclesCounter { get; private set; }

    public void ModifyNumberOfObstacles(int obstaclesDestroyedNumber)
    {
        ObstaclesCounter -= obstaclesDestroyedNumber;
    }
}