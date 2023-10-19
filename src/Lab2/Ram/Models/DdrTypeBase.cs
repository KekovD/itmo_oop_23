namespace Itmo.ObjectOrientedProgramming.Lab2.Ram.Models;

public abstract class DdrTypeBase
{
    protected DdrTypeBase(string name)
    {
        Name = name;
    }

    public string Name { get; protected set; }
}