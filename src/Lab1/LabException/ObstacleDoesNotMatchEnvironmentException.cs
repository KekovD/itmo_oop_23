using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.LabException;

public class ObstacleDoesNotMatchEnvironmentException : Exception
{
    public ObstacleDoesNotMatchEnvironmentException()
        : base("Obstacle does not fit the environment")
    {
    }

    public ObstacleDoesNotMatchEnvironmentException(string message)
        : base(message)
    {
    }

    public ObstacleDoesNotMatchEnvironmentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}