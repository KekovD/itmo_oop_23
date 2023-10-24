using Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.HardDrive.Entities;

public class Hdd : HddBase
{
    public Hdd(
        string name,
        int capacity,
        int spindleSpeed,
        int powerConsumption)
        : base(name, capacity, spindleSpeed, powerConsumption)
    {
    }

    public override HddBase Clone()
    {
        return new Hdd(
            (string)Name.Clone(),
            Capacity,
            SpindleSpeed,
            PowerConsumption);
    }
}